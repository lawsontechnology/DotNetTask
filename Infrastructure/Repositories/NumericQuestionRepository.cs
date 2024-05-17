using ApplicationFormTask.Core.Application.Interface.Repositories;
using ApplicationFormTask.Core.Domain.Entities;
using ApplicationFormTask.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApplicationFormTask.Infrastructure.Repositories
{
    public class NumericQuestionRepository : BaseResponseRepository<NumericQuestion>, INumericQuestionRepository
    {
        public NumericQuestionRepository(ApplicationFormTaskContext context) 
        {
            _context = context;
        }
        public  async Task<ICollection<NumericQuestion>> GetAllAsync()
        {
            return await _context.numericQuestions
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<NumericQuestion> GetAsync(string Id)
        {
            var numeric = await _context.numericQuestions
                .FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted == false);
            return numeric;
        }

        public async Task<NumericQuestion> GetAsync(Expression<Func<NumericQuestion, bool>> predicate)
        {
            var numeric = await _context.numericQuestions
                .Where(x => x.IsDeleted == false)
                .SingleOrDefaultAsync(predicate);
            return numeric;
        }
    }
}
