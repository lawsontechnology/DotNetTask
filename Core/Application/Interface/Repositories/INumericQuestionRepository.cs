using ApplicationFormTask.Core.Domain.Entities;
using System.Linq.Expressions;

namespace ApplicationFormTask.Core.Application.Interface.Repositories
{
    public interface INumericQuestionRepository : IBaseResponseRepository<NumericQuestion>
    {
        Task<NumericQuestion> GetAsync(string Id);
        Task<NumericQuestion> GetAsync(Expression<Func<NumericQuestion, bool>> predicate);
        Task<ICollection<NumericQuestion>> GetAllAsync();
    }
}
