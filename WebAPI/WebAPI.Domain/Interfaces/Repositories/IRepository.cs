using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        public Task Add(T entity);
        public Task Update(T entity);
        public Task Delete(int id);
        public T GetById(int id);
        public Task<IEnumerable<T>> GetAll();
    }
}
