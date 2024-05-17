namespace ApplicationFormTask.Core.Domain.Entities
{
    public class AuditLog : AuditableEntities
    {
        public string Action { get; set; } = default!;
        public DateTime Timestamp { get; set; }
    }
}
