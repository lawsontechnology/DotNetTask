using ApplicationFormTask.Core.Domain.Entities;
using System.Linq.Expressions;

namespace ApplicationFormTask.Core.Application.Interface.Repositories
{
    public interface IMultipleQuestionRepository : IBaseResponseRepository<MultipleQuestion>
    {
        Task<MultipleQuestion> GetAsync(string Id);
        Task<MultipleQuestion> GetAsync(Expression<Func<MultipleQuestion, bool>> predicate);
        Task<ICollection<MultipleQuestion>> GetAllAsync();
    }
}
