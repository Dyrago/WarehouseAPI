using WebAPI.Domain.Entities;
using WebAPI.Infrastructure.Data;

namespace WebAPI.Infrastructure.Seeders
{
    public class Seeder
    {
        private readonly WebAPIDBContext _dbContext;


        public Seeder(WebAPIDBContext dbContext)
        {
                _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if(!_dbContext.Warehouses.Any())
                {
                    var warehouse = new Warehouse()
                    {
                        Name = "Test WH",
                        Description = "Test test",
                        CreationDate = DateTime.Now,
                        Items = new List<Item> {
                            new Item
                            {
                                Name = "Potato",
                                Description = "Test potato",
                                CreatedDate = DateTime.Now,
                                Price = 0.85,
                                Amount = 100,
                            },

                            new Item
                            {
                                Name = "Orange",
                                Description = "Test orange",
                                CreatedDate = DateTime.Now,
                                Price = 1,
                                Quantity = 50,
                            }
                        },

                        Merchant = new Merchant()
                        {
                            Name = "John",
                            Description = "John the merchant",
                        }
                    };

                    _dbContext.Add(warehouse);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
