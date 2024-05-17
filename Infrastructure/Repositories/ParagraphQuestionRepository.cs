using ApplicationFormTask.Core.Application.Interface.Repositories;
using ApplicationFormTask.Core.Domain.Entities;
using ApplicationFormTask.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApplicationFormTask.Infrastructure.Repositories
{
    public class ParagraphQuestionRepository : BaseResponseRepository<ParagraphQuestion>, IParagraphQuestionRepository
    {
        public ParagraphQuestionRepository(ApplicationFormTaskContext context) 
        {
            _context = context;
        }
        public async Task<ICollection<ParagraphQuestion>> GetAllAsync()
        {
            return await _context.paragraphQuestions
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<ParagraphQuestion> GetAsync(string Id)
        {
            var paragraph = await _context.paragraphQuestions
                .FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted == false);
            return paragraph;
        }

        public async Task<ParagraphQuestion> GetAsync(Expression<Func<ParagraphQuestion, bool>> predicate)
        {
            var paragraph = await _context.paragraphQuestions
                .Where(x => x.IsDeleted == false)
            .SingleOrDefaultAsync(predicate);
            return paragraph;
        }
    }
}
