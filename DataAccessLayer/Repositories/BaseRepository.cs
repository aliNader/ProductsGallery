using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T>
    where T : class, IEntity
    {
        protected  SuperMarketDbContext _context;
        public BaseRepository(SuperMarketDbContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T entity)
        {
            return _context.Set<T>().Add(entity).Entity;
           
        }

        public async Task Delete(Guid Id)
        {
            var entity = GetById(Id);
            if (entity == null)
            {
                throw new Exception();
            }
            else
             _context.Set<T>().Remove(entity.Result);
        }

        public async Task<T> GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
