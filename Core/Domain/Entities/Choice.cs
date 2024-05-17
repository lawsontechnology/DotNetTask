namespace ApplicationFormTask.Core.Domain.Entities
{
    public class Choice : AuditableEntities
    {
        public string? Description { get; set; } 
        public string? DropdownQuestionId { get; set; }
        public DropdownQuestion? DropdownQuestion { get; set; }
        public string? MultipleQuestionId { get; set; }
        public MultipleQuestion? MultipleQuestion { get; set; }
        public string? CustomQuestionId { get; set; }
        public CustomQuestion? CustomQuestion { get; set; }
    }
}
