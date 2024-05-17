using ApplicationFormTask.Core.Application.Dto;

namespace ApplicationFormTask.Core.Application.Interface.Services
{
    public interface IPersonalInformationService
    {
        Task<BaseResponse<PersonalInformationDto>> Create(PersonalInformationRequestModel model);
        Task<BaseResponse<PersonalInformationDto>> DeleteInformation(string id);
        Task<BaseResponse<ICollection<PersonalInformationDto>>> GetAllInformation();
        Task<BaseResponse<PersonalInformationDto>> GetInformation(string Email);
    }
}
