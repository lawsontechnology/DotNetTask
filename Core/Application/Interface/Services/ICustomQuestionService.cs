using ApplicationFormTask.Core.Application.Dto;

namespace ApplicationFormTask.Core.Application.Interface.Services
{
    public interface ICustomQuestionService
    {
        Task<BaseResponse<CustomQuestionDto>> GetQuestion(string id);
        Task<BaseResponse<CustomQuestionDto>> CreateQuestion(CustomQuestionRequestModel model);
        Task<BaseResponse<CustomQuestionDto>> UpdateQuestion(CustomQuestionUpdateModel model,string Id);
        Task<BaseResponse<ICollection<CustomQuestionDto>>> GetAllQuestion();
        Task<BaseResponse<CustomQuestionDto>> DeleteQuestion(string id);
    }
}
