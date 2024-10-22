using EjercicioCapas.Bussiness.Entities;
using Microsoft.EntityFrameworkCore;

namespace EjercicioCapas.Data.Repositories
{
    public class AutorRepository
    {
        private readonly AppDBContext _dbContext;
        public AutorRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
            _dbContext.Database.EnsureCreated();
        }

        public Autor FindById(int id)
        {
            var result = _dbContext.Autor.Find(id);
            return result != null ? result : throw new Exception($"No existe autor {id}");
        }

    }
}
