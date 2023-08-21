using WebAPI.Application.DTO.DTOs;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.DTO
{
    public static class DTOConverter
    {
        public static Item DTOToItem(ItemDTO itemDTO)
        {
            return new Item(){
                Name = itemDTO.Name,
                Description = itemDTO.Description,
                Amount = itemDTO.Amount,
                Quantity = itemDTO.Quantity,
                Price = itemDTO.Price,
            };
        }

        public static ItemDTO ItemToDTO(Item item)
        {
            return new ItemDTO()
            {
                Name = item.Name,
                Description = item.Description,
                Amount = item.Amount,
                Quantity = item.Quantity,
                Price = item.Price
            };
        }
    }
}
