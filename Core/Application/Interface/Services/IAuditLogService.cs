using ApplicationFormTask.Core.Application.Dto;

namespace ApplicationFormTask.Core.Application.Interface.Services
{
    public interface IAuditLogService
    {
        Task<BaseResponse<AuditLogDto>> Get(string Action);
        Task<BaseResponse<AuditLogDto>> Get(DateTime TimeStamp);
        Task<BaseResponse<ICollection<AuditLogDto>>> GetAll();
    }
}
