using ApplicationFormTask.Core.Application.Interface.Repositories;
using ApplicationFormTask.Core.Domain.Entities;
using ApplicationFormTask.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApplicationFormTask.Infrastructure.Repositories
{
    public class ProgramEntityRepository : BaseResponseRepository<ProgramEntity>, IProgramEntityRepository
    {
        public ProgramEntityRepository(ApplicationFormTaskContext context) 
        {
            _context = context;
        }
        public async Task<ICollection<ProgramEntity>> GetAllAsync()
        {
            return await _context.programs
                .Where(x => x.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<ProgramEntity> GetAsync(string Id)
        {
            var program = await _context.programs
                .FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted == false);
            return program;
        }

        public async Task<ProgramEntity> GetAsync(Expression<Func<ProgramEntity, bool>> predicate)
        {
            var program = await _context.programs
                .Where(x => x.IsDeleted == false)
                .SingleOrDefaultAsync(predicate);
            return program;
        }
    }
}
