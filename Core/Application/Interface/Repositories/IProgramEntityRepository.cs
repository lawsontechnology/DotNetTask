using ApplicationFormTask.Core.Domain.Entities;
using System.Linq.Expressions;

namespace ApplicationFormTask.Core.Application.Interface.Repositories
{
    public interface IProgramEntityRepository : IBaseResponseRepository<ProgramEntity>
    {
        Task<ProgramEntity> GetAsync(string Id);
        Task<ProgramEntity> GetAsync(Expression<Func<ProgramEntity, bool>> predicate);
        Task<ICollection<ProgramEntity>> GetAllAsync();
    }
}
