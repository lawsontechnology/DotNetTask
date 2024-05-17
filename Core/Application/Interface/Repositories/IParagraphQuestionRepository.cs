using ApplicationFormTask.Core.Domain.Entities;
using System.Linq.Expressions;

namespace ApplicationFormTask.Core.Application.Interface.Repositories
{
    public interface IParagraphQuestionRepository : IBaseResponseRepository<ParagraphQuestion>
    {
        Task<ParagraphQuestion> GetAsync(string Id);
        Task<ParagraphQuestion> GetAsync(Expression<Func<ParagraphQuestion, bool>> predicate);
        Task<ICollection<ParagraphQuestion>> GetAllAsync();
    }
}
