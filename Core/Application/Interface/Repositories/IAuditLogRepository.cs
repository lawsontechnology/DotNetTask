using ApplicationFormTask.Core.Domain.Entities;
using System.Linq.Expressions;

namespace ApplicationFormTask.Core.Application.Interface.Repositories
{
    public interface IAuditLogRepository : IBaseResponseRepository<AuditLog>
    {
        Task<AuditLog> GetAsync(string Id);
        Task<AuditLog> GetAsync(Expression<Func<AuditLog, bool>> predicate);
        Task<ICollection<AuditLog>> GetAllAsync();
    }
}
