namespace ApplicationFormTask.Core.Domain
{
    public abstract class AuditableEntities
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool IsDeleted { get; set; } = false;
        public string? DeletedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
