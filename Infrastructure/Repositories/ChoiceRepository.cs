using ApplicationFormTask.Core.Application.Interface.Repositories;
using ApplicationFormTask.Core.Domain.Entities;
using ApplicationFormTask.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApplicationFormTask.Infrastructure.Repositories
{
    public class ChoiceRepository : BaseResponseRepository<Choice>, IChoiceRepository
    {
        public ChoiceRepository(ApplicationFormTaskContext context) 
        {
            _context = context;
        }
        public async Task<ICollection<Choice>> GetAllAsync()
        {
            return await _context.choices
                .Where(x => x.IsDeleted == false)
               .ToListAsync();
        }

        public async Task<Choice> GetAsync(string Id)
        {
           var choice = await _context.choices
                .FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted == false);
            return choice;
        }

        public async Task<Choice> GetAsync(Expression<Func<Choice, bool>> predicate)
        {
            var choice = await _context.choices
                .Where(x => x.IsDeleted == false)
               .SingleOrDefaultAsync(predicate);
            return choice;
        }
    }
}
