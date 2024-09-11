using Microsoft.EntityFrameworkCore;
using PruebaLibreria.Data;
using PruebaLibreria.DTOs;
using PruebaLibreria.Entities;
using PruebaLibreria.Interfaces;
using System.Threading.Tasks;

namespace PruebaLibreria.Services
{
    public class AutorService : IAutorService
    {
        private readonly ApplicationDbContext _context;

        public AutorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RegistrarAutor(AutorDto autorDto)
        {
            var autor = new Autor
            {
                Rut = autorDto.Rut,
                NombreCompleto = autorDto.NombreCompleto,
                FechaNacimiento = autorDto.FechaNacimiento,
                CiudadProcedencia = autorDto.CiudadProcedencia,
                CorreoElectronico = autorDto.CorreoElectronico
            };

            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
        }

        public async Task<Autor> ObtenerAutorPorRut(string rut)
        {
            return await _context.Autores.FindAsync(rut);
        }

        public async Task<bool> AutorExiste(string rut)
        {
            return await _context.Autores.AnyAsync(a => a.Rut == rut);
        }
    }
}
