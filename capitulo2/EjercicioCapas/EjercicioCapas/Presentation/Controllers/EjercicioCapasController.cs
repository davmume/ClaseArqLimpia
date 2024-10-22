using EjercicioCapas.Bussiness.Services;
using EjercicioCapas.Data.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioCapas.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjercicioCapasController : ControllerBase
    {
        private readonly IOperacionesServices _operacionesService;
        public EjercicioCapasController(IOperacionesServices operacionesServices)
        {
            _operacionesService = operacionesServices;
        }
        [HttpPost]
        [Route(nameof(InsertarLibro))]
        public IActionResult InsertarLibro([FromBody] BookDTO dto)
        {
            try
            {
                var result = _operacionesService.Insert(dto);
                return result > 0 ? Created() : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route(nameof(ObtenerTodosLosLibros))]
        public IActionResult ObtenerTodosLosLibros()
        {
            return Ok(_operacionesService.ObtenerTodosLosLibros());
        }

        [HttpGet]
        [Route(nameof(BuscarLibrosPorAutor))]
        public IActionResult BuscarLibrosPorAutor(int AutorId)
        {

            var libros = _operacionesService.BuscarPorAutor(AutorId);

            return Ok(libros);
        }
    }
}
