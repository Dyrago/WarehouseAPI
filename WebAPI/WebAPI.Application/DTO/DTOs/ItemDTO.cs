namespace WebAPI.Application.DTO.DTOs
{
    public class ItemDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; } = 0;
        public double Amount { get; set; } = 0;
    }
}
