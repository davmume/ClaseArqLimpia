using EjercicioCapas.Bussiness.Entities;
using Microsoft.EntityFrameworkCore;

namespace EjercicioCapas.Data.Repositories
{
    public class BookRepository 
    { 
        private readonly AppDBContext _dbContext;
        public BookRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
            _dbContext.Database.EnsureCreated();
        }

        public int Insert(Book book)
        {
            _dbContext.Book.Add(book);
            var result = _dbContext.SaveChanges();
            return result;
        }

        public List<Book> FindById(int idAutor)
        {
            var result = _dbContext.Book.Include(x=>x.Autor).Where(x=> x.AutorId == idAutor).ToList();
            return result;
        }

        public List<Book> GetAll()
        {
            return _dbContext.Book
                .Include(t => t.Autor)                
                .ToList();
        }

    }
}
