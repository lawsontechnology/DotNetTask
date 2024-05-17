using ApplicationFormTask.Core.Application.Dto;
using ApplicationFormTask.Core.Application.Interface.Repositories;
using ApplicationFormTask.Core.Application.Interface.Services;
using ApplicationFormTask.Core.Domain.Entities;
using Microsoft.Extensions.Logging;
using NLog;

namespace ApplicationFormTask.Core.Application.Implementation.Service
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _auditLogRepo;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public AuditLogService(IAuditLogRepository auditLog)
        {
            _auditLogRepo = auditLog;
        }
        public async Task<BaseResponse<AuditLogDto>> Get(string Action)
        {
            try
            {
                var audit = await _auditLogRepo.GetAsync(x => x.Action == Action);
                if (audit == null)
                {
                    logger.Info($"Action {Action} Can Not be Found");
                    return new BaseResponse<AuditLogDto>
                    {
                        Message = "Action can Not Be Found",
                        Status = false
                    };
                }
                var auditLog = new AuditLog
                {
                    Action = $"Successfully Retrieving {Action} From The AuditLog DataBase Table ",
                    Timestamp = DateTime.Now,
                };
                await _auditLogRepo.CreateAsync(auditLog);
                await _auditLogRepo.SaveAsync();
                logger.Info($"Successfully Retrieving {Action} From The AuditLog DataBase Table");
                return new BaseResponse<AuditLogDto>
                {
                    Message = "Action Found Successful",
                    Status = true,
                    Data = new AuditLogDto
                    {
                        Action = audit.Action,
                        Timestamp = audit.Timestamp,
                        Id = audit.Id,

                    }
                };
            }
            catch (Exception error)
            {
                logger.Error($"When getting this {Action}", error);

            }
            return null;

        }

        public async Task<BaseResponse<AuditLogDto>> Get(DateTime TimeStamp)
        {
            try
            {
                var audit = await _auditLogRepo.GetAsync(x => x.Timestamp == TimeStamp);
                if (audit == null)
                {
                    logger.Info($"TimeStamp {TimeStamp} Can Not Be Found");
                    return new BaseResponse<AuditLogDto>
                    {
                        Message = $"TimeStamp{TimeStamp} can Not Be Found",
                        Status = false
                    };
                }
                var auditLog = new AuditLog
                {
                    Action = $"Successfully Retrieving {TimeStamp} From The AuditLog DataBase Table ",
                    Timestamp = DateTime.Now,
                };
                await _auditLogRepo.CreateAsync(auditLog);
                await _auditLogRepo.SaveAsync();
                logger.Info($"Successfully Retrieving {TimeStamp} From The AuditLog DataBase Table");
                return new BaseResponse<AuditLogDto>
                {
                    Message = "Action Found Successful",
                    Status = true,
                    Data = new AuditLogDto
                    {
                        Action = audit.Action,
                        Timestamp = audit.Timestamp,
                        Id = audit.Id,

                    }
                };
            }
            catch (Exception error)
            {
                logger.Error($"When Retrieving this {TimeStamp}", error);

            }
            return null;
        }

        public async Task<BaseResponse<ICollection<AuditLogDto>>> GetAll()
        {
            try
            {
                var audit = await _auditLogRepo.GetAllAsync();
                if (audit == null)
                {
                    logger.Info($" Retrieving All AuditLog Data Is UnSuccessful");
                    return new BaseResponse<ICollection<AuditLogDto>>
                    {
                        Message = "AuditLog Data Not Be Found",
                        Status = false,
                    };
                }
                var listOfAuditLog = audit.Select(x => new AuditLogDto
                {
                    Action = x.Action,
                    Timestamp = x.Timestamp,
                    Id = x.Id,
                }).ToList();
                var auditLog = new AuditLog
                {
                    Action = "Retrieving AuditLog Data From DataBase",
                    Timestamp = DateTime.UtcNow,

                };
                await _auditLogRepo.CreateAsync(auditLog);
                await _auditLogRepo.SaveAsync();
                return new BaseResponse<ICollection<AuditLogDto>>
                {
                    Message = $"Retrieving All AuditLog Data ",
                    Status = true,
                    Data = listOfAuditLog,
                };
            }
            catch(Exception error) 
            {
                logger.Error( error, "Occur When Retrieving All AuditLog Data From DataBase");
            }
            return null;
        }
    }
}
