using Microsoft.EntityFrameworkCore;
using PruebaLibreria.Data;
using PruebaLibreria.DTOs;
using PruebaLibreria.Entities;
using PruebaLibreria.Interfaces;
using System;
using System.Threading.Tasks;

namespace PruebaLibreria.Services
{
    public class LibroService : ILibroService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAutorService _autorService;

        public LibroService(ApplicationDbContext context, IAutorService autorService)
        {
            _context = context;
            _autorService = autorService;
        }

        public async Task RegistrarLibro(LibroDto libroDto)
        {
            var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Rut == libroDto.AutorRut);
            if (autor == null)
            {
                throw new Exception("El autor no está registrado");
            }

            var librosDelAutor = await _context.Libros.Where(l => l.AutorRut == libroDto.AutorRut).ToListAsync();
            if (librosDelAutor.Count >= 10)
            {
                throw new Exception("No es posible registrar el libro, se alcanzó el máximo permitido");
            }

            var libro = new Libro
            {
                Titulo = libroDto.Titulo,
                Anio = libroDto.Anio,
                Genero = libroDto.Genero,
                NumeroPaginas = libroDto.NumeroPaginas,
                AutorRut = libroDto.AutorRut
            };

            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
        }



        public async Task<object> BuscarLibros(
            string? palabraClave, string? rutAutor, string? titulo, int? anio,
            string? nombreAutor, int pagina, int tamanoPagina)
        {
            var query = _context.Libros.Include(l => l.Autor).AsQueryable();

            // Filtros opcionales
            if (!string.IsNullOrEmpty(palabraClave))
            {
                query = query.Where(l => l.Titulo.Contains(palabraClave) || l.Autor.NombreCompleto.Contains(palabraClave));
            }

            if (!string.IsNullOrEmpty(rutAutor))
            {
                query = query.Where(l => l.AutorRut == rutAutor);
            }

            if (!string.IsNullOrEmpty(titulo))
            {
                query = query.Where(l => l.Titulo.Contains(titulo));
            }

            if (anio.HasValue)
            {
                query = query.Where(l => l.Anio == anio);
            }

            if (!string.IsNullOrEmpty(nombreAutor))
            {
                query = query.Where(l => l.Autor.NombreCompleto.Contains(nombreAutor));
            }

            // Paginación
            var totalResultados = await query.CountAsync();
            var resultados = await query
                .Skip((pagina - 1) * tamanoPagina)
                .Take(tamanoPagina)
                .ToListAsync();

            return new
            {
                TotalResultados = totalResultados,
                PaginaActual = pagina,
                TamanoPagina = tamanoPagina,
                Resultados = resultados
            };
        }
    }
}