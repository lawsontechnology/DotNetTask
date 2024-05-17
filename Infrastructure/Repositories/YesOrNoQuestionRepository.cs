using ApplicationFormTask.Core.Application.Interface.Repositories;
using ApplicationFormTask.Core.Domain.Entities;
using ApplicationFormTask.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace ApplicationFormTask.Infrastructure.Repositories
{
    public class YesOrNoQuestionRepository : BaseResponseRepository<YesOrNoQuestion>, IYesOrNoQuestionRepository
    {
        public YesOrNoQuestionRepository(ApplicationFormTaskContext context)
        {
           _context = context;
        }
        public async Task<ICollection<YesOrNoQuestion>> GetAllAsync()
        {
           return await _context.yesOrNoQuestions
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<YesOrNoQuestion> GetAsync(string Id)
        {
            var yesOrNo = await _context.yesOrNoQuestions
                .FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted == false);
            return yesOrNo;
        }

        public async Task<YesOrNoQuestion> GetAsync(Expression<Func<YesOrNoQuestion, bool>> expression)
        {
            var yesOrNo = await _context.yesOrNoQuestions
                .Where(x => x.IsDeleted == false)
                .SingleOrDefaultAsync(expression);
            return yesOrNo;
        }
    }
}
