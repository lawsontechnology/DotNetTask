using ApplicationFormTask.Core.Application.Dto;
using ApplicationFormTask.Core.Application.Interface.Repositories;
using ApplicationFormTask.Core.Application.Interface.Services;
using ApplicationFormTask.Core.Domain.Entities;
using NLog;

namespace ApplicationFormTask.Core.Application.Implementation.Service
{
    public class QuestionTypesService : IQuestionTypesService
    {
        private readonly ICustomQuestionRepository _customQuestionRepo;
        private readonly IDateQuestionRepository _dateQuestionRepo;
        private readonly IDropdownQuestionRepository _dropQuestionRepo;
        private readonly IMultipleQuestionRepository _multipleQuestionRepo;
        private readonly INumericQuestionRepository _numericQuestionRepo;
        private readonly IParagraphQuestionRepository _paragraphQuestionRepo;
        private readonly IYesOrNoQuestionRepository _yesOrNoQuestionRepo;
        private readonly IAuditLogRepository _auditLogRepo;
        private readonly IChoiceRepository _choiceRepo;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public QuestionTypesService(ICustomQuestionRepository custom, IDateQuestionRepository date, IDropdownQuestionRepository dropdown, IMultipleQuestionRepository multiple,
           INumericQuestionRepository numeric, IParagraphQuestionRepository paragraph, IYesOrNoQuestionRepository yesOrNo, IAuditLogRepository auditLogRepo, IChoiceRepository choiceRepo)
        {
            _customQuestionRepo = custom;
            _dateQuestionRepo = date;
            _dropQuestionRepo = dropdown;
            _multipleQuestionRepo = multiple;
            _numericQuestionRepo = numeric;
            _paragraphQuestionRepo = paragraph;
            _yesOrNoQuestionRepo = yesOrNo;
            _auditLogRepo = auditLogRepo; 
            _choiceRepo = choiceRepo;
        }

        public async Task<BaseResponse<DateQuestionDto>> CreateDateQuestion(DateQuestionRequest model)
        {
            try
            {
                var date = new DateQuestion
                {
                    QuestionText = model.QuestionText,
                    QuestionType = model.QuestionType,

                };
                var auditLog = new AuditLog
                {
                    Action = "Creating A New DateQuestion",
                    Timestamp = DateTime.UtcNow,
                };
                await _auditLogRepo.CreateAsync(auditLog);
                await _dateQuestionRepo.CreateAsync(date);
                await _dateQuestionRepo.SaveAsync();
                logger.Info("Successfully Created A new DateQuestion");
                return new BaseResponse<DateQuestionDto>
                {
                    Status = true,
                    Message = "Successfully Created",
                };
            }
            catch (Exception error) 
            {
                logger.Error(error);
            }
            return null;
        }

        public async Task<BaseResponse<DropdownQuestionDto>> CreateDropdownQuestion(DropdownQuestionRequestModel model)
        {
            try
            {
                var dropDown = new DropdownQuestion
                {
                    QuestionText = model.QuestionText,
                    QuestionType = model.QuestionType,
                    OtherOption = model.OtherOption,
                      
                };
                var choice = new Choice
                {
                    DropdownQuestion = dropDown,
                    DropdownQuestionId = dropDown.Id,
                    Description = model.ChoiceDescription,
                };
                var auditLog = new AuditLog
                {
                    Action = "Creating A new DropDown Question",
                    Timestamp = DateTime.UtcNow,
                };
                await _dropQuestionRepo.CreateAsync(dropDown);
                await _choiceRepo.CreateAsync(choice);
                await _auditLogRepo.CreateAsync(auditLog);
                await _dropQuestionRepo.SaveAsync();
                logger.Info("Successfully Created A new DropDown Question");
                return new BaseResponse<DropdownQuestionDto>
                {
                    Status = true,
                    Message = "Successfully Created",
                };

            }
            catch (Exception error)
            {
                logger.Error(error);
            }
            return null;
        }

        public async Task<BaseResponse<MultipleQuestionDto>> CreateMultipleQuestion(MultipleQuestionRequestModel model)
        {
            try
            {
                var multiple = new MultipleQuestion
                {
                    QuestionText = model.QuestionText,
                    QuestionType = model.QuestionType,
                    MaxChoiceCount = model.MaxChoiceCount,
                    OtherOption = model.OtherOption,
                };
                var choice = new Choice
                {
                     MultipleQuestionId = multiple.Id,
                     MultipleQuestion = multiple,
                    Description = model.ChoiceDescription,
                };
                var auditLog = new AuditLog
                {
                    Action = "Creating A new Multiple Question",
                    Timestamp = DateTime.UtcNow,
                };
                await _multipleQuestionRepo.CreateAsync(multiple);
                await _choiceRepo.CreateAsync(choice);
                await _auditLogRepo.CreateAsync(auditLog);
                await _multipleQuestionRepo.SaveAsync();
                logger.Info("Successfully Created A new Multiple Question");
                return new BaseResponse<MultipleQuestionDto>
                {
                    Status = true,
                    Message = "Successfully Created",
                };

            }
            catch (Exception error)
            {
                logger.Error(error);
            }
            return null;
        }

        public async Task<BaseResponse<NumericQuestionDto>> CreateNumericQuestion(NumericQuestionRequestModel model)
        {
            try
            {
                var numeric= new NumericQuestion
                {
                    QuestionText = model.QuestionText,
                    QuestionType = model.QuestionType,

                };
                var auditLog = new AuditLog
                {
                    Action = "Creating A New DateQuestion",
                    Timestamp = DateTime.UtcNow,
                };
                await _auditLogRepo.CreateAsync(auditLog);
                await _numericQuestionRepo.CreateAsync(numeric);
                await _numericQuestionRepo.SaveAsync();
                logger.Info("Successfully Created A new NumericQuestion");
                return new BaseResponse<NumericQuestionDto>
                {
                    Status = true,
                    Message = "Successfully Created",
                };
            }
            catch (Exception error)
            {
                logger.Error(error);
            }
            return null;
        }

        public async Task<BaseResponse<ParagraphQuestionDto>> CreateParagraphQuestion(ParagraphQuestionRequestModel model)
        {
            try
            {
                var paragraph = new ParagraphQuestion
                {
                    QuestionText = model.QuestionText,
                    QuestionType = model.QuestionType,

                };
                var auditLog = new AuditLog
                {
                    Action = "Creating A New ParagraphQuestion",
                    Timestamp = DateTime.UtcNow,
                };
                await _auditLogRepo.CreateAsync(auditLog);
                await _paragraphQuestionRepo.CreateAsync(paragraph);
                await _paragraphQuestionRepo.SaveAsync();
                logger.Info("Successfully Created A new ParagraphQuestion");
                return new BaseResponse<ParagraphQuestionDto>
                {
                    Status = true,
                    Message = "Successfully Created",
                };
            }
            catch (Exception error)
            {
                logger.Error(error);
            }
            return null;
        }

        public async Task<BaseResponse<YesOrNoQuestionDto>> CreateYesOrNoQuestion(YesOrNoQuestionRequestModel model)
        {
            try
            {
                var yesOrNo = new YesOrNoQuestion
                {
                    QuestionText = model.QuestionText,
                    QuestionType = model.QuestionType,

                };
                var auditLog = new AuditLog
                {
                    Action = "Creating A New YesOrNoQuestion",
                    Timestamp = DateTime.UtcNow,
                };
                await _auditLogRepo.CreateAsync(auditLog);
                await _yesOrNoQuestionRepo.CreateAsync(yesOrNo);
                await _yesOrNoQuestionRepo.SaveAsync();
                logger.Info("Successfully Created A new YesOrNOQuestion");
                return new BaseResponse<YesOrNoQuestionDto>
                {
                    Status = true,
                    Message = "Successfully Created",
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
