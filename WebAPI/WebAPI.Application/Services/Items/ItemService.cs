using WebAPI.Application.DTO;
using WebAPI.Application.DTO.DTOs;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces.Repositories;

namespace WebAPI.Application.Services.Items
{
    public class ItemService
    {
        private readonly IRepository<Item> _repository;

        public ItemService(IRepository<Item> repository) { _repository = repository; }

        public void Add(Item item) { _repository.Add(item); }
        public void Delete(int id) { _repository.Delete(id); }
        public void Update(Item item) { _repository.Update(item); }
        //public Item GetById(int id) {  return _repository.GetById(id); }
        public ItemDTO GetById(int id) { return DTOConverter.ItemToDTO(_repository.GetById(id)); }
        public IEnumerable<Item> GetAll()
        {
            var items = _repository.GetAll();
            if (items.Result.Any())
                return items.Result;
            return Enumerable.Empty<Item>();
        }

    }
}
