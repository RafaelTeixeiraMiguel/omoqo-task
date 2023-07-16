using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace API.Test.Repositories.Mocks
{
    public class BaseRepositoryMock<T> : IBaseRepository<T> where T : BaseEntity
    {
        private List<T> _entities = new List<T>();

        public Task<T> Create(T entity)
        {
            _entities.Add(entity);

            return Task.FromResult(entity);
        }

        public Task Delete(Guid id)
        {
            T? entity =  _entities.SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Delete aborted, element not found");
            }

            return Task.FromResult(_entities.Remove(entity));
        }

        public Task<T?> GetById(Guid id)
        {
            return Task.FromResult(_entities.SingleOrDefault(x => x.Id == id));
        }

        public Task<IEnumerable<T>> ListAll(Expression<Func<T, bool>>? where = null, int? skip = null, int? take = null)
        {
            IEnumerable<T> entities = _entities.ToList();

            if(where != null)
            {
                entities = entities.Where(where.Compile()).ToList();
            }

            if(skip != null)
            {
                entities = entities.Skip(skip ?? 0).ToList();
            }

            if (take != null)
            {
                entities = entities.Take(take ?? 0).ToList();
            }

            return Task.FromResult(entities);
        }

        public Task<T> Update(T entity)
        {
            var index = _entities.FindIndex(x => entity.Id == x.Id);
            if (index == -1)
            {
                throw new KeyNotFoundException("Element not found");
            }
            _entities[index] = entity;

            return Task.FromResult(entity);
        }
    }
}
