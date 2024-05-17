using ApplicationFormTask.Core.Domain.Entities;
using System.Linq.Expressions;

namespace ApplicationFormTask.Core.Application.Interface.Repositories
{
    public interface IYesOrNoQuestionRepository : IBaseResponseRepository<YesOrNoQuestion>
    {
        Task<YesOrNoQuestion> GetAsync(string Id);
        Task<YesOrNoQuestion> GetAsync(Expression<Func<YesOrNoQuestion, bool>> expression);
        Task<ICollection<YesOrNoQuestion>> GetAllAsync();
    }
}
