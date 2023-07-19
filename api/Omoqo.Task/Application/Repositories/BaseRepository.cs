using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq.Expressions;

namespace Application.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;
        protected readonly DbSet<T> _dbSet;

        protected BaseRepository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(Guid id)
        {
            T? entity = await GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Delete aborted, element not found");
            }
        }

        public async Task<T?> GetById(Guid id)
        {
            T? entity= await _dbSet.SingleOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                throw new KeyNotFoundException("Element not found");
            }
        }

        public async Task<IEnumerable<T>> ListAll()
        {
            IQueryable<T> query = _dbSet;

            return await query.ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            T? dataEntity = await _dbSet.SingleOrDefaultAsync(x => x.Id == entity.Id);
            if (dataEntity != null)
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            else
            {
                throw new KeyNotFoundException("Element not found");
            }
            
        }
    }
}
