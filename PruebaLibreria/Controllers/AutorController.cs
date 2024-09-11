using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PruebaLibreria.DTOs;
using PruebaLibreria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PruebaLibreria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarAutor(AutorDto autorDto)
        {
            try
            {
                await _autorService.RegistrarAutor(autorDto);
                return Ok(new { mensaje = "Autor registrado exitosamente" });
            }
            catch (DbUpdateException dbEx)
            {
                return BadRequest(new { mensaje = "Error de base de datos: " + dbEx.InnerException?.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

    }
}
