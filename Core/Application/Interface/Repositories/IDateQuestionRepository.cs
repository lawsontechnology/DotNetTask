using ApplicationFormTask.Core.Domain.Entities;
using System.Linq.Expressions;

namespace ApplicationFormTask.Core.Application.Interface.Repositories
{
    public interface IDateQuestionRepository : IBaseResponseRepository<DateQuestion>
    {
        Task<DateQuestion> GetAsync(string Id);
        Task<DateQuestion> GetAsync(Expression<Func<DateQuestion, bool>> predicate);
        Task<ICollection<DateQuestion>> GetAllAsync();
    }
}
