using ApplicationFormTask.Core.Domain.Enum;

namespace ApplicationFormTask.Core.Domain.Entities
{
    public class CustomQuestion : AuditableEntities
    {
        
        public string QuestionText { get; set; } = default!;
        public QuestionType QuestionType { get; set; }
        public ICollection<Choice> Choices { get; set; } = new HashSet<Choice>();
        public string? OtherOption { get; set; } 
        
    }
}
