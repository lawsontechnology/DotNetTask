using ApplicationFormTask.Core.Domain.Entities;
using System.Linq.Expressions;

namespace ApplicationFormTask.Core.Application.Interface.Repositories
{
    public interface IPersonalInformationRepository : IBaseResponseRepository<PersonalInformation>
    {
        Task<PersonalInformation> GetAsync(string email);
        Task<PersonalInformation> GetAsync(Expression<Func<PersonalInformation, bool>> predicate);
        Task<ICollection<PersonalInformation>> GetAllAsync();
    }
}
