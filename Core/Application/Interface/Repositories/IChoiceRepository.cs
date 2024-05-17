using ApplicationFormTask.Core.Domain.Entities;
using System.Linq.Expressions;

namespace ApplicationFormTask.Core.Application.Interface.Repositories
{
    public interface IChoiceRepository : IBaseResponseRepository<Choice>
    {
        Task<Choice> GetAsync(string Id);
        Task<Choice> GetAsync(Expression<Func<Choice, bool>> predicate);
        Task<ICollection<Choice>> GetAllAsync();
    }
}
