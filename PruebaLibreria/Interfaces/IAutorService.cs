using PruebaLibreria.DTOs;
using PruebaLibreria.Entities;
using System.Threading.Tasks;

namespace PruebaLibreria.Interfaces
{
    public interface IAutorService
    {
        Task RegistrarAutor(AutorDto autorDto);
        Task<Autor> ObtenerAutorPorRut(string rut);
        Task<bool> AutorExiste(string rut);
    }
}
