using ApplicationFormTask.Core.Domain.Enum;

namespace ApplicationFormTask.Core.Application.Dto
{
    public class YesOrNoQuestionDto
    {
        public string Id { get; set; } = default!;
        public string QuestionText = default!;
        public string? QuestionType { get; set; }
    }

    public class YesOrNoQuestionRequestModel
    {
        public string QuestionText = default!;
        public QuestionType QuestionType { get; set; }
    }
}
