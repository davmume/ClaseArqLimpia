using Microsoft.EntityFrameworkCore;
using ReservacionesRestful.Bussiness.Entities;

namespace ReservacionesRestful.Data.Repositories
{
    public class ReservationRepository
    {
        private readonly AppDBContext _dbContext;
        public ReservationRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
            _dbContext.Database.EnsureCreated();
        }

        public int Insert(Reservation resevation)
        {
            _dbContext.Reservations.Add(resevation);
            var result=_dbContext.SaveChanges();
            return result;
        }

        public Reservation FindById(int id)
        {
            var result = _dbContext.Reservations.Find(id);
            return result != null ? result : throw new Exception($"No existe reservacion {id}");
        }

        public List<Reservation> GetAlL()
        {
            return _dbContext.Reservations
                .Include(t => t.Room)
                .Include(t => t.User)
                .ToList();
        }

    }
}
