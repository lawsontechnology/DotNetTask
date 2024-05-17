using ApplicationFormTask.Core.Domain.Entities;
using ApplicationFormTask.Core.Domain.Enum;

namespace ApplicationFormTask.Core.Application.Dto
{
    public class CustomQuestionDto
    {
        public string Id { get; set; } = default!;
        public string QuestionText { get; set; } = default!;
        public string? QuestionType { get; set; }
        public ICollection<ChoiceDto> Choices { get; set; } = new HashSet<ChoiceDto>();
        public string? OtherOption { get; set; }
    }
    public class CustomQuestionRequestModel
    {
        public string QuestionText { get; set; } = default!;
        public QuestionType QuestionType { get; set;}
        public string? OtherOption { get; set; }
        public string? ChoiceDescription { get; set; }
    }
    public class CustomQuestionUpdateModel
    {
        public string? QuestionText {  get; set; }
        public QuestionType QuestionType { get; set; }
    }
}
