using MicroservicioPerros.Bussiness.Entities;
using MicroservicioPerros.Data.DTOs;
using MicroservicioPerros.Data.Repositories;

namespace MicroservicioPerros.Bussiness.Services
{
    public class DogServiceImpl : IDogService
    {
        private readonly DogRepository _dogRepository;
        public DogServiceImpl(DogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }
        public int Delete(int id)
        {
            return _dogRepository.Delete(id);
        }

        public List<DogDTO> GetAll()
        {
            return _dogRepository.GetAll()
                .Select(x=> new DogDTO { 
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                MaxLife = x.MaxLife,
                UrlImage = x.UrlImage
            }).ToList();
        }

        public int Insert(DogDTO dto)
        {
            return _dogRepository.Insert(new Dog() {
            Name=dto.Name,
            Description=dto.Description,
            MaxLife=dto.MaxLife,
            UrlImage=dto.UrlImage});
        }
    }
}
