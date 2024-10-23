using MicroservicioPerros.Data.DTOs;

namespace MicroservicioPerros.Bussiness.Services
{
    public interface IDogService
    {
        int Insert(DogDTO dto);
        List<DogDTO> GetAll();
        int Delete(int id);        
    }
}