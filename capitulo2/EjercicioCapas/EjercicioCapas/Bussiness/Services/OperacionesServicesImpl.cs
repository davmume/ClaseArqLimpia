using EjercicioCapas.Bussiness.Entities;
using EjercicioCapas.Data.DTOs;
using EjercicioCapas.Data.Repositories;

namespace EjercicioCapas.Bussiness.Services
{
    public class OperacionesServicesImpl : IOperacionesServices
    {
        private readonly AutorRepository _autorRepository;
        private readonly BookRepository _bookRepository;
        public OperacionesServicesImpl(
            AutorRepository autorRepository,
            BookRepository bookRepository)
        {
            _autorRepository = autorRepository;
            _bookRepository = bookRepository;
        }

        public List<Book> BuscarPorAutor(int idAutor)
        {

            return _bookRepository.FindById(idAutor);
        }

        public int Insert(BookDTO dto)
        {
            //busqueda de autor
            Autor autor = new();
            try
            {
                autor = _autorRepository.FindById(dto.AutorId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"no existe el autor {ex.Message}");
                throw;
            }
       
                Book book = new()
                {                   
                    Name = dto.Name,
                    Description = dto.Description,
                    AutorId = dto.AutorId
                };
                int result = _bookRepository.Insert(book);
                return result;                       
        }

        public List<Book> ObtenerTodosLosLibros()
        {
            return _bookRepository.GetAll(); ;
        }
    }
}
