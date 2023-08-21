using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces.Repositories;
using WebAPI.Infrastructure.Data;

namespace WebAPI.Infrastructure.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        private readonly WebAPIDBContext _context; 
        public ItemRepository(WebAPIDBContext context) { _context = context; }

        public Task Add(Item entity)
        {
            if (entity != null)
            {
                 _context.Add(entity);
                 _context.SaveChanges();

                return Task.CompletedTask;
            }
            else
                throw new ArgumentNullException(nameof(entity));
        }

        public async Task Delete(int id)
        {
            if (id > 0)
            {
                var item = new Item() { Id = id };
                _context.Remove(item);
                await _context.SaveChangesAsync();
            }
            else
                throw new Exception(message: "Id can't be equal 0");
        }

        public async Task Update(Item entity)
        {
            if (entity != null)
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
            }
            else
                throw new ArgumentNullException(nameof(entity));
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await _context.Items.OrderBy(i => i.Id).ToListAsync();
        }

        public Item GetById(int id)
        {
            var item = _context.Items.FirstOrDefault(x => x.Id == id);
            if (item != null)
                return item;
            else
                throw new Exception(message: $"There is no item by ID: {id}");
        }
    }
}
