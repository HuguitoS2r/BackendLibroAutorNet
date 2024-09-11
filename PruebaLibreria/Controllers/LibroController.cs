using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using PruebaLibreria.DTOs;
using PruebaLibreria.Interfaces;

namespace PruebaLibreria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarLibro(LibroDto libroDto)
        {
            try
            {
                await _libroService.RegistrarLibro(libroDto);
                return Ok(new { mensaje = "Libro registrado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarLibros(
            [FromQuery] string? palabraClave,
            [FromQuery] string? rutAutor,
            [FromQuery] string? titulo,
            [FromQuery] int? anio,
            [FromQuery] string? nombreAutor,
            [FromQuery] int pagina = 1,
            [FromQuery] int tamanoPagina = 10)
        {
            try
            {
                var resultados = await _libroService.BuscarLibros(
                    palabraClave, rutAutor, titulo, anio, nombreAutor, pagina, tamanoPagina);

                return Ok(resultados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
