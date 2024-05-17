using System.Linq.Expressions;

namespace ApplicationFormTask.Core.Application.Interface.Repositories
{
    public interface IBaseResponseRepository<T>
    {
        Task<T> CreateAsync(T entity);
        bool Check(Expression<Func<T, bool>> predicate);
        Task<int> SaveAsync();
    }
}
