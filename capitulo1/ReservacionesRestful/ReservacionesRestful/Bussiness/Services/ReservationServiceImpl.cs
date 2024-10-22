using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ReservacionesRestful.Bussiness.Entities;
using ReservacionesRestful.Data.DTO_s;
using ReservacionesRestful.Data.Repositories;

namespace ReservacionesRestful.Bussiness.Services
{
    public class ReservationServiceImpl : IReservationService
    {
        private readonly UserRepository _userRepository;
        private readonly ReservationRepository _reservationRepository;
        private readonly RoomRepository _roomRepository;

        public ReservationServiceImpl(
            UserRepository userRepository, 
            ReservationRepository reservationRepository, 
            RoomRepository roomRepository)
        {
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
            _roomRepository = roomRepository;
        }

        public List<Reservation> GetAll()
        {
            return _reservationRepository.GetAlL();
        }

        public int Insert(ReservationDTO dto)
        {
            //busqueda de usuario
            User user = new();
            try
            {
                user = _userRepository.FindById(dto.UserId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"no existe el usuario {ex.Message}");
                throw;
            }

            //Busqueda de cuarto
            Room room = new();
            try
            {
                room = _roomRepository.FindById(dto.RoomId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"no existe el cuarto {ex.Message}");
                throw;
            }

            if (room.Available)
            {
                Reservation reservation = new() {
                    UserId=dto.UserId,
                    RoomId=dto.RoomId,
                    Begin=dto.Beging,
                    End=dto.End
                };
                int result= _reservationRepository.Insert(reservation);
                room.Available = false;
                _roomRepository.Update(room);
                return result;
            }

            throw new Exception($"habitación no disponible {room.RoomId}");
        }

        public List<Room> GetAvailableRooms()
        {
            return _roomRepository.GetAvailable();
        }
    }
}
