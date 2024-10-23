using MicroservicioPerros.Bussiness.Services;
using MicroservicioPerros.Data.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicioPerros.Presentation.Controllers
{
    [EnableCors("AllowAny")]
    [Route("api/[controller]")]//http://ip:port/api/Dog
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly IDogService _dogService;
        public DogController(IDogService dogService)
        {
            _dogService = dogService;
        }

        [HttpPost]
        //[Route(nameof(InsertarDog))]
        public IActionResult InsertarDog([FromBody] DogDTO dto)
        {
            try
            {
                _dogService.Insert(dto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        //[Route(nameof(GetAll))]
        public IActionResult GetAll()
        {
            return Ok(_dogService.GetAll());
        }

        [HttpDelete]
        //[Route(nameof(Delete))]
        public IActionResult Delete(int id)
        {
            try
            {
                _dogService.Delete(id);
                return Ok("Perro eliminado");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}