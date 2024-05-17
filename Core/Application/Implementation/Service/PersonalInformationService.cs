using ApplicationFormTask.Core.Application.Dto;
using ApplicationFormTask.Core.Application.Interface.Repositories;
using ApplicationFormTask.Core.Application.Interface.Services;
using ApplicationFormTask.Core.Domain.Entities;
using ApplicationFormTask.Infrastructure.Repositories;
using NLog;

namespace ApplicationFormTask.Core.Application.Implementation.Service
{
    public class PersonalInformationService : IPersonalInformationService
    {
        private readonly IPersonalInformationRepository _personalInformationRepo;
        private readonly IAuditLogRepository _auditLogRepo;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public PersonalInformationService(IPersonalInformationRepository personal, IAuditLogRepository audit)
        {
            _personalInformationRepo = personal;
            _auditLogRepo = audit;
        }
        public async Task<BaseResponse<PersonalInformationDto>> Create(PersonalInformationRequestModel model)
        {
            try
            {
            var personal = new PersonalInformation
            {
                 CurrentResidence = model.CurrentResidence,
                 DOB = model.DOB,
                 Email = model.Email,
                 FirstName = model.FirstName,
                 LastName = model.LastName,
                 IDNumber = model.IDNumber,
                 PhoneNumber = model.PhoneNumber,
                 QuestionTypeToAnswer = model.QuestionTypeToAnswer,
                 Nationality = model.Nationality,
                 Gender = model.Gender,
                
            };
            var auditLog = new AuditLog
            {
                Action = "Creating A New User",
                Timestamp = DateTime.UtcNow,
            };
            await _personalInformationRepo.CreateAsync(personal);
            await _auditLogRepo.CreateAsync(auditLog);
            await _personalInformationRepo.SaveAsync();
            logger.Info("Successfully Created a new User");
            return new BaseResponse<PersonalInformationDto>
            {
                 Status = true,
                  Message = "Successfully Created ",
                   Data = new PersonalInformationDto
                   {
                      CurrentResidence = personal.CurrentResidence,
                      DOB = personal.DOB,
                      Email = personal.Email,
                      FirstName = personal.FirstName,
                      LastName = personal.LastName,
                      IDNumber = personal.IDNumber,
                      PhoneNumber = personal.PhoneNumber,
                      Gender = personal.Gender.ToString(),
                      Id = personal.Id,
                      Nationality = personal.Nationality,
                      QuestionTypeToAnswer = personal.QuestionTypeToAnswer.ToString(),
                   }
            };

            }
            catch (Exception error) 
            {
                logger.Error(error);
            }
            return null;
        }

        public async Task<BaseResponse<PersonalInformationDto>> DeleteInformation(string id)
        {
            try
            {

                var personal = await _personalInformationRepo.GetAsync(id);
                if (personal == null)
                {
                    logger.Info($"Id : {id} CanNot Be Found In The DataBase");
                    return new BaseResponse<PersonalInformationDto>
                    {
                        Status = false,
                        Message = $"Id : {id} CanNot Be Found In the DataBase",
                    };

                }
                var auditLog = new AuditLog
                {
                    Action = $"Property with this Id : {id} is Deleted",
                    Timestamp = DateTime.UtcNow,
                };
                await _auditLogRepo.CreateAsync(auditLog);
                personal.IsDeleted = true;
                await _personalInformationRepo.SaveAsync();
                logger.Info($"Successfully Deleted Id:{id} Property");
                return new BaseResponse<PersonalInformationDto>
                {
                    Message = "Successfully Deleted",
                    Status = true,
                };
            }
            catch (Exception error)
            {
                logger.Error(error);
            }
            return null;
        }

        public async Task<BaseResponse<ICollection<PersonalInformationDto>>> GetAllInformation()
        {
            try
            {
                List<PersonalInformationDto> listOfPersonalInformation = new List<PersonalInformationDto>();
                var personalInformation = await _personalInformationRepo.GetAllAsync();
                foreach (var personal in personalInformation)
                {
                    var personalList = new PersonalInformationDto
                    {
                        CurrentResidence = personal.CurrentResidence,
                        DOB = personal.DOB,
                        Email = personal.Email,
                        FirstName = personal.FirstName,
                        LastName = personal.LastName,
                        IDNumber = personal.IDNumber,
                        PhoneNumber = personal.PhoneNumber,
                        Gender = personal.Gender.ToString(),
                        Id = personal.Id,
                        Nationality = personal.Nationality,
                        QuestionTypeToAnswer = personal.QuestionTypeToAnswer.ToString(),
                    };
                    listOfPersonalInformation.Add(personalList);
                }
                var auditLog = new AuditLog
                {
                    Action = "Retrieving All PersonalInformation From DataBase",
                    Timestamp = DateTime.UtcNow,
                };
                await _auditLogRepo.CreateAsync(auditLog);
                await _auditLogRepo.SaveAsync();
                logger.Info("Retrieving All PersonalInformation From DataBase");
                return new BaseResponse<ICollection<PersonalInformationDto>>
                {
                     Data = listOfPersonalInformation,
                     Message = "Retrieving All PersonalInformation From DataBase",
                      Status = true
                };
            }
            catch (Exception error) 
            {
                logger.Error(error);
            }
            return null;
        }

        public async Task<BaseResponse<PersonalInformationDto>> GetInformation(string Email)
        {
           try
           {
               var personal = await _personalInformationRepo.GetAsync(Email);
               if(personal == null) 
                {
                    logger.Info($"Email: {Email} Cannot be found");
                    return new BaseResponse<PersonalInformationDto>
                    {
                        Message = $"{Email} Cannot be found From The DataBase",
                        Status = false,
                    };
                }
                var auditLog = new AuditLog
                {
                   Action = $"Getting Property Of This Email:{Email}",
                   Timestamp = DateTime.UtcNow,
                };
                await _auditLogRepo.CreateAsync(auditLog);
                await _auditLogRepo.SaveAsync();
                logger.Info($"Successfully Retrieved this Email: {Email} Property");
                return new BaseResponse<PersonalInformationDto>
                {
                     Status = true,
                     Message = "Successfully Retrieved",
                     Data = new PersonalInformationDto
                     {
                         CurrentResidence = personal.CurrentResidence,
                         DOB = personal.DOB,
                         Email = personal.Email,
                         FirstName = personal.FirstName,
                         LastName = personal.LastName,
                         IDNumber = personal.IDNumber,
                         PhoneNumber = personal.PhoneNumber,
                         Gender = personal.Gender.ToString(),
                         Id = personal.Id,
                         Nationality = personal.Nationality,
                         QuestionTypeToAnswer = personal.QuestionTypeToAnswer.ToString(),
                     }
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
