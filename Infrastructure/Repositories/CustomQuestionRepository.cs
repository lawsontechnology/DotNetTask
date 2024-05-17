using ApplicationFormTask.Core.Application.Interface.Repositories;
using ApplicationFormTask.Core.Domain.Entities;
using ApplicationFormTask.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApplicationFormTask.Infrastructure.Repositories
{
    public class CustomQuestionRepository : BaseResponseRepository<CustomQuestion>, ICustomQuestionRepository
    {
        public CustomQuestionRepository(ApplicationFormTaskContext context) 
        {
            _context = context;
        }
        public async Task<ICollection<CustomQuestion>> GetAllAsync()
        {
            return await _context.customQuestions
                .Where(x => x.IsDeleted == false)
            .ToListAsync();
        }

        public async Task<CustomQuestion> GetAsync(string Id)
        {
            var custom = await _context.customQuestions
                .FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted == false);
            return custom;
        }

        public async Task<CustomQuestion> GetAsync(Expression<Func<CustomQuestion, bool>> predicate)
        {
            var custom = await _context.customQuestions
                .Where(x => x.IsDeleted == false)
           .SingleOrDefaultAsync(predicate);
            return custom;
        }
    }
}
