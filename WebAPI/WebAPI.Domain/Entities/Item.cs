namespace WebAPI.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set;}
        public double Price { get; set; }
        public int Quantity { get; set; } = 0;
        public double Amount { get; set; } = 0;
        public Warehouse? Warehouses { get; set; } = null;
    }
}
