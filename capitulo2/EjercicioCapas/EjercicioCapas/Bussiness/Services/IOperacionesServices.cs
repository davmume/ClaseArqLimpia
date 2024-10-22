using EjercicioCapas.Bussiness.Entities;
using EjercicioCapas.Data.DTOs;

namespace EjercicioCapas.Bussiness.Services
{
    public interface IOperacionesServices
    {
        List<Book> ObtenerTodosLosLibros();
        int Insert(BookDTO dto);
        List<Book> BuscarPorAutor(int idAutor);
    }
}
