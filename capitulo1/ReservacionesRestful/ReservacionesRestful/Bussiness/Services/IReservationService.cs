using ReservacionesRestful.Bussiness.Entities;
using ReservacionesRestful.Data.DTO_s;

namespace ReservacionesRestful.Bussiness.Services
{
    public interface IReservationService
    {
        List<Reservation> GetAll();
        int Insert(ReservationDTO dto);
        List<Room> GetAvailableRooms();
    }
}
