using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Entities;

namespace WebAPI.Infrastructure.Data
{
    public class WebAPIDBContext : DbContext
    {
        public WebAPIDBContext(DbContextOptions<WebAPIDBContext> options) : base(options){}

        public DbSet<Item> Items { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet <Merchant> Merchants { get; set; }
    }
}
