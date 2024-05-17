using ApplicationFormTask.Core.Domain.Entities;
using ApplicationFormTask.Core.Domain.Enum;

namespace ApplicationFormTask.Core.Application.Dto
{
    public class MultipleQuestionDto
    {
        public string Id { get; set; } = default!;
        public string QuestionText = default!;
        public string? QuestionType { get; set; }
        public ICollection<Choice> Choices { get; set; } = new HashSet<Choice>();
        public string? OtherOption { get; set; }
        public byte MaxChoiceCount { get; set; }
    }
    public class MultipleQuestionRequestModel
    {
        public string QuestionText = default!;
        public QuestionType QuestionType { get; set; }
        public string? OtherOption { get; set; }
        public byte MaxChoiceCount { get; set; }
        public string? ChoiceDescription { get; set; }
    }
}
