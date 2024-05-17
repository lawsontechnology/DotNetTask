using ApplicationFormTask.Core.Application.Dto;

namespace ApplicationFormTask.Core.Application.Interface.Services
{
    public interface IQuestionTypesService
    {
        Task<BaseResponse<DateQuestionDto>> CreateDateQuestion(DateQuestionRequest model);
        Task<BaseResponse<DropdownQuestionDto>> CreateDropdownQuestion(DropdownQuestionRequestModel model);
        Task<BaseResponse<MultipleQuestionDto>> CreateMultipleQuestion(MultipleQuestionRequestModel model);
        Task<BaseResponse<NumericQuestionDto>> CreateNumericQuestion(NumericQuestionRequestModel model);
        Task<BaseResponse<ParagraphQuestionDto>> CreateParagraphQuestion(ParagraphQuestionRequestModel model);
        Task<BaseResponse<YesOrNoQuestionDto>> CreateYesOrNoQuestion(YesOrNoQuestionRequestModel model);

    }
}
