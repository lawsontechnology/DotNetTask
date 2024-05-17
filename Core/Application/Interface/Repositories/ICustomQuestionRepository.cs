using ApplicationFormTask.Core.Domain.Entities;
using System.Linq.Expressions;

namespace ApplicationFormTask.Core.Application.Interface.Repositories
{
    public interface ICustomQuestionRepository : IBaseResponseRepository<CustomQuestion>
    {
        Task<CustomQuestion> GetAsync(string Id);
        Task<CustomQuestion> GetAsync(Expression<Func<CustomQuestion, bool>> predicate);
        Task<ICollection<CustomQuestion>> GetAllAsync();
    }
}
