using ApplicationFormTask.Core.Domain.Enum;

namespace ApplicationFormTask.Core.Application.Dto
{
    public class DateQuestionDto
    {
        public string Id { get; set; } = default!;
        public string QuestionText = default!;
        public string? QuestionType { get; set; }
    }
    public class DateQuestionRequest
    {
        public string QuestionText = default!;
        public QuestionType QuestionType { get; set; }
    }

}
