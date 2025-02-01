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

        public async Task<Result<T>> Create(T entity)
        {
            if (!entity.IsValid)
            {
                return new Result<T>(entity.Errors);
            }

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return new Result<T>(entity); ;
        }

        public async Task<Result> Delete(Guid id)
        {
            Result<T?> selectResult = await GetById(id);

            if (!selectResult.Success)
                return new Result<T>(selectResult.Errors);

            if (selectResult.Value == null)
                return new Result<T>($"Element not found. Id: {id}");

            _dbSet.Remove(selectResult.Value);
            await _context.SaveChangesAsync();

            return new Result<T>(selectResult.Value);
        }

        public async Task<Result<T?>> GetById(Guid id)
        {
            return new Result<T?>(_dbSet.SingleOrDefault(x => x.Id == id));
        }

        public async Task<Result<IEnumerable<T>>> ListAll()
        {
            IQueryable<T> query = _dbSet;

            return new Result<IEnumerable<T>>(await query.ToListAsync());
        }

        public async Task<Result<T>> Update(T entity)
        {
            try
            {
                if (!entity.IsValid)
                    return new Result<T>(entity.Errors);

                T updateResult = _dbSet.Update(entity).Entity;
                await _context.SaveChangesAsync();

                return new Result<T>(entity);
            }
            catch (Exception ex)
            {
                return new Result<T>(ex);
            }

        }
    }
}
