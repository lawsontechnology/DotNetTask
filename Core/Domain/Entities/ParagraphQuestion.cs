using ApplicationFormTask.Core.Domain.Enum;

namespace ApplicationFormTask.Core.Domain.Entities
{
    public class ParagraphQuestion : AuditableEntities
    {
        public string QuestionText = default!;
        public QuestionType QuestionType { get; set; }
    }
}
