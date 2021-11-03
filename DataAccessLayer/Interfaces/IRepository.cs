using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T: class
    {
        Task<T> GetById(Guid Id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T entity);
        Task Delete(Guid Id);
        Task<T> Update(T entity);
        int SaveChanges();
    }
}
