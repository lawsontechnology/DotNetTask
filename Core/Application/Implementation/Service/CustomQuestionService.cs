using ApplicationFormTask.Core.Application.Dto;
using ApplicationFormTask.Core.Application.Interface.Repositories;
using ApplicationFormTask.Core.Application.Interface.Services;
using ApplicationFormTask.Core.Domain.Entities;
using ApplicationFormTask.Core.Domain.Enum;
using NLog;

namespace ApplicationFormTask.Core.Application.Implementation.Service
{
    public class CustomQuestionService : ICustomQuestionService
    {
        private readonly ICustomQuestionRepository _customQuestionRepo;
        private readonly IChoiceRepository _choiceRepo;
        private readonly IAuditLogRepository _auditLogRepo;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public CustomQuestionService(ICustomQuestionRepository custom, IChoiceRepository choiceRepo, IAuditLogRepository auditLogRepo)
        {
            _customQuestionRepo = custom;
            _choiceRepo = choiceRepo;
            _auditLogRepo = auditLogRepo;   
        }
        public async Task<BaseResponse<CustomQuestionDto>> CreateQuestion(CustomQuestionRequestModel model)
        {
            try
            {
                
                var Custom = new CustomQuestion
                {
                    QuestionType = model.QuestionType,
                    OtherOption = model.OtherOption,
                    QuestionText = model.QuestionText,

                };
                var choice = new Choice
                {
                     CustomQuestionId = Custom.Id,
                     CustomQuestion = Custom,
                     Description = model.ChoiceDescription,
                        
                };
                var auditLog = new AuditLog
                {
                     Action = "Creating A new Custom Question" ,
                     Timestamp = DateTime.UtcNow,
                };
                await _customQuestionRepo.CreateAsync(Custom);
                await _choiceRepo.CreateAsync(choice);
                await _auditLogRepo.CreateAsync(auditLog);
                await _auditLogRepo.SaveAsync();
                logger.Info("Successfully Create A New Custom Question");
                return new BaseResponse<CustomQuestionDto>
                {
                    Message = "Successfully Create A New Custom Question",
                    Status = true,
                };
            }
            catch (Exception ex) 
            {
                 logger.Error(ex,"Occur When Creating A New Custom Question");
            }
            return null;
        }

        public async Task<BaseResponse<CustomQuestionDto>> DeleteQuestion(string id)
        {
            try
            {
                var custom = await _customQuestionRepo.GetAsync(id);
                if (custom == null)
                {
                    logger.Info($"{id}: Cannot Be Found from CustomQuestion DataBase");
                    return new BaseResponse<CustomQuestionDto>
                    {
                        Message = "Id Cannot be found",
                        Status = false,
                    };
                };
                var audit = new AuditLog
                {
                    Action = $"Deleting this {id} Data With the Use Of SoftDelete",
                    DeletedBy = "User",
                    Timestamp = DateTime.UtcNow
                };
                await _auditLogRepo.CreateAsync(audit);
                custom.IsDeleted = true;
                await _auditLogRepo.SaveAsync();
                logger.Info($" Successfully Delete this {id} Data With the Use Of SoftDelete");
                return new BaseResponse<CustomQuestionDto>
                {
                    Message = "Successful deleted",
                    Status = true,
                };
            }
            catch(Exception error)
            {
                logger.Error(error, $"Occur when Deleting this {id} Property");
            }

            return null; 
            
        }

        public async Task<BaseResponse<ICollection<CustomQuestionDto>>> GetAllQuestion()
        {
            try
            {

            List<CustomQuestionDto> listOfCustom = new List<CustomQuestionDto>();
            var custom = await _customQuestionRepo.GetAllAsync();
            foreach (var customQuestion in custom) 
            {
                var customList = new CustomQuestionDto
                {
                    Id = customQuestion.Id,
                    OtherOption = customQuestion.OtherOption,
                    QuestionText = customQuestion.QuestionText,
                    QuestionType = customQuestion.QuestionType.ToString(),
                    Choices = customQuestion.Choices.Select(x => new ChoiceDto
                    {
                         Id = x.Id,
                        Description = x.Description,
                         
                    }).ToList(),
                };
                listOfCustom.Add(customList);
            }

            var auditLog = new AuditLog
            {
                 Action = "Retrieving All CustomQuestion From DataBase",
                 Timestamp = DateTime.UtcNow,
            };
            await _auditLogRepo.CreateAsync(auditLog);
            await _auditLogRepo.SaveAsync();
            logger.Info("Retrieving All CustomQuestion From DataBase");
            return new BaseResponse<ICollection<CustomQuestionDto>>
            {
                Data = listOfCustom,
                Message = " Retrieved Successfully",
                Status = true,
            };
            }
            catch(Exception error) 
            {
                logger.Error(error, "Occur when ReRetrieving All CustomQuestion From DataBase");
            }
            return null;


        }

        public async Task<BaseResponse<CustomQuestionDto>> GetQuestion(string id)
        {
            var customQuestion = await _customQuestionRepo.GetAsync(id);
            if(customQuestion == null)
            {
                logger.Info($"{id}: Cannot Be Found From DataBase");
                return new BaseResponse<CustomQuestionDto>
                {
                     Message = $"This Id {id} CanNot Be Found",
                     Status = false,
                };
            }
            var auditLog = new AuditLog
            {
                Action = $"Retrieving this Id :{id} Property",
                Timestamp = DateTime.UtcNow,
            };
            await _auditLogRepo.CreateAsync(auditLog);
            await _auditLogRepo.SaveAsync();
            return new BaseResponse<CustomQuestionDto>
            {
                 Message = "Retrieving Successfully",
                  Status = true,
                   Data = new CustomQuestionDto
                   {
                       Id = customQuestion.Id,
                       OtherOption = customQuestion.OtherOption,
                       QuestionText = customQuestion.QuestionText,
                       QuestionType = customQuestion.QuestionType.ToString(),
                       Choices = customQuestion.Choices.Select(x => new ChoiceDto
                       {
                           Id = x.Id,
                           Description = x.Description,

                       }).ToList(),
                   },
            };
        }

        public async Task<BaseResponse<CustomQuestionDto>> UpdateQuestion(CustomQuestionUpdateModel model, string Id)
        {
            try
            {
                var customQuestion = await _customQuestionRepo.GetAsync(Id);
                if (customQuestion == null)
                {
                    logger.Info($"Id: {Id} cannot be Found");
                    return new BaseResponse<CustomQuestionDto>
                    {
                        Message = $"Id: {Id} cannot be Found From The DataBase",
                        Status = false,
                    };
                }
                customQuestion.Id = Id;
                customQuestion.QuestionText = model.QuestionText;
                customQuestion.QuestionType = model.QuestionType;
                var auditLog = new AuditLog
                {
                    Action = $"Updating CustomQuestion Of this Id :{Id}",
                    Timestamp = DateTime.UtcNow,
                    ModifiedBy = "User"
                };
                await _auditLogRepo.CreateAsync(auditLog);
                await _customQuestionRepo.SaveAsync();
                logger.Info($"Updating CustomQuestion Of this Id :{Id}");
                return new BaseResponse<CustomQuestionDto>
                {
                    Message = "Successfully Updated",
                    Status = true,
                    Data = new CustomQuestionDto
                    {
                        Id = customQuestion.Id,
                        OtherOption = customQuestion.OtherOption,
                        QuestionText = customQuestion.QuestionText,
                        QuestionType = customQuestion.QuestionType.ToString(),
                        Choices = customQuestion.Choices.Select(x => new ChoiceDto
                        {
                            Id = x.Id,
                            Description = x.Description,

                        }).ToList(),
                    }
                };
            }
            catch(Exception error) 
            {
                logger.Error(error);
            }
            return null;
        }
    }
}
