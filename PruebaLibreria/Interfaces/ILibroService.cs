using PruebaLibreria.DTOs;
using PruebaLibreria.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaLibreria.Interfaces
{
    public interface ILibroService
    {
        Task RegistrarLibro(LibroDto libroDto);

        Task<object> BuscarLibros(
            string? palabraClave,
            string? rutAutor,
            string? titulo,
            int? anio,
            string? nombreAutor,
            int pagina,
            int tamanoPagina);
    }
}
