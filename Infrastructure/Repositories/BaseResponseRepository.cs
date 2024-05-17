using ApplicationFormTask.Core.Application.Interface.Repositories;
using ApplicationFormTask.Infrastructure.Context;
using System.Linq.Expressions;

namespace ApplicationFormTask.Infrastructure.Repositories
{
    public class BaseResponseRepository<T> : IBaseResponseRepository<T> where T : class
    {
        public ApplicationFormTaskContext _context;
        public bool Check(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }

        public async Task<T> CreateAsync(T entity)
        {
             await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        
    }
}
