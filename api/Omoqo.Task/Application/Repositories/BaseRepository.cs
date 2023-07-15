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

        public async Task<IEnumerable<T>> ListAll(Expression<Func<T, bool>>? where = null,
            int? skip = null, int? take = null)
        {
            IQueryable<T> query = _dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (skip != null)
            {
                query = query.Skip(skip ?? 0);
            }

            if (take != null)
            {
                query = query.Take(take ?? 10);
            }

            return await query.ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
