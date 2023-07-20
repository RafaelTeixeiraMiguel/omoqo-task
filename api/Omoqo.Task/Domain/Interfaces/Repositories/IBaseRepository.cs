using Domain.Entities;
using Domain.Models;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<Result<T?>> GetById(Guid id);
        Task<Result<IEnumerable<T>>> ListAll();
        Task<Result<T>> Create(T entity);
        Task<Result<T>> Update(T entity);
        Task<Result> Delete(Guid id);
    }
}
