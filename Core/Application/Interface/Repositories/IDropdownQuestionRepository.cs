using ApplicationFormTask.Core.Domain.Entities;
using System.Linq.Expressions;

namespace ApplicationFormTask.Core.Application.Interface.Repositories
{
    public interface IDropdownQuestionRepository : IBaseResponseRepository<DropdownQuestion>
    {
        Task<DropdownQuestion> GetAsync(string Id);
        Task<DropdownQuestion> GetAsync(Expression<Func<DropdownQuestion,bool>> predicate);
        Task<ICollection<DropdownQuestion>> GetAllAsync();
    }
}
