using ApplicationFormTask.Core.Application.Dto;

namespace ApplicationFormTask.Core.Application.Interface.Services
{
    public interface IProgramEntityService
    {
        Task<BaseResponse<ProgramEntityDto>> Get(string Id);
        Task<BaseResponse<ProgramEntityDto>> Delete(string Id);
        Task<BaseResponse<ProgramEntityDto>> Create(ProgramEntityRequestModel model);
        Task<BaseResponse<ICollection<ProgramEntityDto>>> GetAll();
    }
}
