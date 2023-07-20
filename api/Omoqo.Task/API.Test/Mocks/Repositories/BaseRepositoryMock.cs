using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.VisualStudio.CodeCoverage;
using System.Linq.Expressions;

namespace API.Test.Repositories.Mocks
{
    public class BaseRepositoryMock<T> : IBaseRepository<T> where T : BaseEntity
    {
        private List<T> _entities = new List<T>();

        public async Task<Result<T>> Create(T entity)
        {

            if(entity.IsValid) {
                return new Result<T>(entity.Errors);
            }

            _entities.Add(entity);

            return new Result<T>(entity);
        }

        public async Task<Result> Delete(Guid id)
        {
            T? entity =  _entities.SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Delete aborted, element not found");
            }

            _entities.Remove(entity);

            return new Result();
        }

        public async Task<Result<T?>> GetById(Guid id)
        {
            return new Result<T?>(_entities.SingleOrDefault(x => x.Id == id));
        }

        public async Task<Result<IEnumerable<T>>> ListAll()
        {
            IEnumerable<T> entities = _entities.ToList();

            return new Result<IEnumerable<T>>(entities);
        }

        public async Task<Result<T>> Update(T entity)
        {
            var index = _entities.FindIndex(x => entity.Id == x.Id);
            if (index == -1)
            {
                throw new KeyNotFoundException("Element not found");
            }
            _entities[index] = entity;

            return new Result<T>(entity);
        }
    }
}
