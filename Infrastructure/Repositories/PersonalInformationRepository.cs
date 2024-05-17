using ApplicationFormTask.Core.Application.Interface.Repositories;
using ApplicationFormTask.Core.Domain.Entities;
using ApplicationFormTask.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApplicationFormTask.Infrastructure.Repositories
{
    public class PersonalInformationRepository : BaseResponseRepository<PersonalInformation>, IPersonalInformationRepository
    {
        public PersonalInformationRepository(ApplicationFormTaskContext context) 
        {
            _context = context;
        }
        public async Task<ICollection<PersonalInformation>> GetAllAsync()
        {
            return await _context.PersonalInformation
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<PersonalInformation> GetAsync(string email)
        {
            var personal = await _context.PersonalInformation
                .FirstOrDefaultAsync(x => x.Email == email && x.IsDeleted == false);
            return personal;
        }

        public async Task<PersonalInformation> GetAsync(Expression<Func<PersonalInformation, bool>> predicate)
        {
            var personal = await _context.PersonalInformation
                .Where(x => x.IsDeleted == false)
              .SingleOrDefaultAsync(predicate);
            return personal;
        }
    }
}
