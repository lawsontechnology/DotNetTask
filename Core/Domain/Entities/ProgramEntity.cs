namespace ApplicationFormTask.Core.Domain.Entities
{
    public class ProgramEntity : AuditableEntities 
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
