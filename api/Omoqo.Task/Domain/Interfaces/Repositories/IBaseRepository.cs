using Domain.Entities;
using Domain.Models;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T?> GetById(Guid id);
        Task<IEnumerable<T>> ListAll(Expression<Func<T, bool>>? where = null, int? skip = null, int? take = null);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(Guid id);
    }
}
