using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservacionesRestful.Bussiness.Services;
using ReservacionesRestful.Data.DTO_s;

namespace ReservacionesRestful.Presentation.Controllers
{
    [Route("api/[controller]")] //http://ip:port/api/Resarvation
    [ApiController]
    //POST-Insert
    //PUT-Actualizacion
    //PATCH-Actualización parcial
    //GET-Consultas
    //DELETE-Borrar
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        [HttpPost]
        public IActionResult Create([FromBody] ReservationDTO dto)
        {
            try
            {
                var result = _reservationService.Insert(dto);
                return result >0 ? Created():BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_reservationService.GetAll());
        }

        [HttpGet("rooms")]
        public IActionResult GetAvailableRooms()
        {
            return Ok(_reservationService.GetAvailableRooms());
        }
    }
}
