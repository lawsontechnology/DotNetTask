using ApplicationFormTask.Core.Application.Interface.Repositories;
using ApplicationFormTask.Core.Domain.Entities;
using ApplicationFormTask.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApplicationFormTask.Infrastructure.Repositories
{
    public class MultipleQuestionRepository : BaseResponseRepository<MultipleQuestion>, IMultipleQuestionRepository
    {
        public MultipleQuestionRepository(ApplicationFormTaskContext context) 
        {
            _context = context;
        }
        public async Task<ICollection<MultipleQuestion>> GetAllAsync()
        {
           return await _context.multipleQuestions
                .Include(x => x.Choices)
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<MultipleQuestion> GetAsync(string Id)
        {
           var multiple = await _context.multipleQuestions
                .Include(x=> x.Choices)
                .FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted == false);
            return multiple;
        }

        public async Task<MultipleQuestion> GetAsync(Expression<Func<MultipleQuestion, bool>> predicate)
        {
            var multiple = await _context.multipleQuestions
                .Include (x => x.Choices)
                .Where(x => x.IsDeleted == false)
                .SingleOrDefaultAsync(predicate);
            return multiple;
        }
    }
}
