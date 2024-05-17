using ApplicationFormTask.Core.Application.Interface.Repositories;
using ApplicationFormTask.Core.Domain.Entities;
using ApplicationFormTask.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApplicationFormTask.Infrastructure.Repositories
{
    public class DateQuestionRepository : BaseResponseRepository<DateQuestion>, IDateQuestionRepository
    {
        public DateQuestionRepository(ApplicationFormTaskContext context) 
        {
            _context = context;
        }
        public async Task<ICollection<DateQuestion>> GetAllAsync()
        {
            return await _context.dateQuestions
                .Where(x => x.IsDeleted == false)
           .ToListAsync();
        }

        public async Task<DateQuestion> GetAsync(string Id)
        {
            var date = await _context.dateQuestions
                .FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted == false);
            return date;
        }

        public async Task<DateQuestion> GetAsync(Expression<Func<DateQuestion, bool>> predicate)
        {
           var date = await _context.dateQuestions
                .Where(x => x.IsDeleted == false)
                .SingleOrDefaultAsync(predicate);
            return date;
        }
    }
}
