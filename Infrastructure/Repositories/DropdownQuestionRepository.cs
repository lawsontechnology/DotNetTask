using ApplicationFormTask.Core.Application.Interface.Repositories;
using ApplicationFormTask.Core.Domain.Entities;
using ApplicationFormTask.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApplicationFormTask.Infrastructure.Repositories
{
    public class DropdownQuestionRepository : BaseResponseRepository<DropdownQuestion>, IDropdownQuestionRepository
    {
        public DropdownQuestionRepository(ApplicationFormTaskContext context) 
        {
            _context = context;
        }
        public async Task<ICollection<DropdownQuestion>> GetAllAsync()
        {
            return await _context.dropdownQuestions
                .Include(x => x.Choices)
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<DropdownQuestion> GetAsync(string Id)
        {
            var drop = await _context.dropdownQuestions
                .Include(x => x.Choices)
                .FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted == false);
            return drop;
        }

        public async Task<DropdownQuestion> GetAsync(Expression<Func<DropdownQuestion, bool>> predicate)
        {
            var drop = await _context.dropdownQuestions 
                .Include(x => x.Choices)
                .Where(x => x.IsDeleted == false)
                .SingleOrDefaultAsync(predicate);
            return drop;

        }
    }
}
