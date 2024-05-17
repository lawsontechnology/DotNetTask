using ApplicationFormTask.Core.Application.Interface.Repositories;
using ApplicationFormTask.Core.Domain.Entities;
using ApplicationFormTask.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApplicationFormTask.Infrastructure.Repositories
{
    public class AuditLogRepository : BaseResponseRepository<AuditLog>,IAuditLogRepository
    {
        public AuditLogRepository(ApplicationFormTaskContext context) 
        {
            _context = context;
        }

        public async Task<ICollection<AuditLog>> GetAllAsync()
        {
            return await _context.AuditLogs
                .Where(x => x.IsDeleted == false)
                .ToListAsync(); 
        }

        public async Task<AuditLog> GetAsync(string Id)
        {
            var auditLog = await _context.AuditLogs
                .FirstOrDefaultAsync(x => x.Id == Id && x.IsDeleted == false);
            return auditLog;
        }

        public async Task<AuditLog> GetAsync(Expression<Func<AuditLog, bool>> predicate)
        {
            var auditLog = await _context.AuditLogs
                .Where(x => x.IsDeleted == false)
                .SingleOrDefaultAsync(predicate);
            return auditLog;
        }
    }
}
