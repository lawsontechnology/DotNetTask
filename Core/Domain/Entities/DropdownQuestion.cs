using ApplicationFormTask.Core.Domain.Enum;

namespace ApplicationFormTask.Core.Domain.Entities
{
    public class DropdownQuestion : AuditableEntities
    {
        public string QuestionText = default!;
        public QuestionType QuestionType { get; set; }
        public ICollection<Choice> Choices { get; set; } = new HashSet<Choice>();
        public string? OtherOption{ get; set; }
    }
}
