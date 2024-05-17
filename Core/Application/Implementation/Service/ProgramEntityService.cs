using ApplicationFormTask.Core.Application.Dto;
using ApplicationFormTask.Core.Application.Interface.Repositories;
using ApplicationFormTask.Core.Application.Interface.Services;
using ApplicationFormTask.Core.Domain.Entities;
using Microsoft.Extensions.Logging;
using NLog;

namespace ApplicationFormTask.Core.Application.Implementation.Service
{
    public class ProgramEntityService : IProgramEntityService
    {
        private readonly IProgramEntityRepository _programEntityRepo;
        private readonly IAuditLogRepository _auditLogRepo;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public ProgramEntityService(IProgramEntityRepository program, IAuditLogRepository auditLogRepo)
        {
            _programEntityRepo = program;
            _auditLogRepo = auditLogRepo;
        }

        public async Task<BaseResponse<ProgramEntityDto>> Create(ProgramEntityRequestModel model)
        {
            try
            {
                var programEntity = new ProgramEntity
                {
                    Description = model.Description,
                    Title = model.Title,

                };
                var auditLog = new AuditLog
                {
                    Action = "Creating A New Program",
                    Timestamp = DateTime.UtcNow,
                };
                await _programEntityRepo.CreateAsync(programEntity);
                await _auditLogRepo.CreateAsync(auditLog);
                await _programEntityRepo.SaveAsync();
                return new BaseResponse<ProgramEntityDto>
                {
                    Status = true,
                    Message = "Successfully Created",
                    Data = new ProgramEntityDto
                    {
                        Title = programEntity.Title,
                        Description = programEntity.Description,
                        Id = programEntity.Id
                    }
                };
            }
            catch (Exception error) 
            {
                logger.Error(error);
            }
            return null;
          
        }

        public async Task<BaseResponse<ProgramEntityDto>> Delete(string Id)
        {
            try
            {
                var programEntity = await _programEntityRepo.GetAsync(Id);
                if (programEntity == null)
                {
                    logger.Info($"Id : {Id} CanNot Be Found In the DataBase");
                    return new BaseResponse<ProgramEntityDto>
                    {
                        Status = true,
                        Message = $"Id : {Id} CanNot Be Found In the DataBase",
                    };
                }
                var auditLog = new AuditLog
                {
                    Action = $"Property with this Id : {Id} is Deleted",
                    Timestamp = DateTime.UtcNow,
                };
                await _auditLogRepo.CreateAsync(auditLog);
                programEntity.IsDeleted = true;
                await _programEntityRepo.SaveAsync();
                logger.Info($"Successfully Deleted Id:{Id} Property");
                return new BaseResponse<ProgramEntityDto>
                {
                    Status = true,
                    Message = "Successfully Retrieved",
                    Data = new ProgramEntityDto
                    {
                        Description = programEntity.Description,
                        Id = programEntity.Id,
                        Title = programEntity.Title,
                    }
                };
            }
            catch (Exception error ) 
            {
                logger.Error(error);
            }
            return null;
        }

        public async Task<BaseResponse<ProgramEntityDto>> Get(string Id)
        {
            try
            {
                var programEntity = await _programEntityRepo.GetAsync(Id);
                if (programEntity == null)
                {
                    logger.Info($"Id : {Id} CanNot Be Found In the DataBase");
                    return new BaseResponse<ProgramEntityDto>
                    {
                        Status = false,
                        Message = $"Id : {Id} CanNot Be Found In the DataBase"
                    };
                }
                var auditLog = new AuditLog
                {
                    Action = $"Property with this Id : {Id} is Retrieved",
                    Timestamp = DateTime.UtcNow,
                };
                await _auditLogRepo.CreateAsync(auditLog);
                await _programEntityRepo.SaveAsync();
                logger.Info($"Successfully Retrieved Id:{Id} Property");
                return new BaseResponse<ProgramEntityDto>
                {
                    Status = true,
                    Message = "Successfully Retrieved",
                    Data = new ProgramEntityDto
                    {
                        Description = programEntity.Description,
                        Id = programEntity.Id,
                        Title = programEntity.Title,
                    }
                };
            }
            catch ( Exception error ) 
            {
                logger.Error(error);
            }
            return null;
        }

        public async Task<BaseResponse<ICollection<ProgramEntityDto>>> GetAll()
        {
            try
            {
                List<ProgramEntityDto> listOfProgramEntities = new List<ProgramEntityDto>();
                var program = await _programEntityRepo.GetAllAsync();
                foreach (var programEntity in program)
                {
                    var programList = new ProgramEntityDto
                    {
                        Description = programEntity.Description,
                        Id = programEntity.Id,
                        Title = programEntity.Title,

                    };
                    listOfProgramEntities.Add(programList);
                }
                var auditLog = new AuditLog
                {
                    Action = "Retrieving All ProgramEntity From DataBase",
                    Timestamp = DateTime.UtcNow,
                };
                await _auditLogRepo.CreateAsync(auditLog);
                await _auditLogRepo.SaveAsync();
                logger.Info("Retrieving All ProgramEntity From DataBase");
                return new BaseResponse<ICollection<ProgramEntityDto>>
                {
                    Message = "Retrieving All Successfully",
                    Status = true,
                    Data = listOfProgramEntities
                };
            }
            catch (Exception error) 
            {
                logger.Error(error);
            }
            return null;
        }
    }
}
