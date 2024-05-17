namespace ApplicationFormTask.Core.Application.Dto
{
    public class AuditLogDto
    {
        public string Id { get; set; } = default!;
        public string Action { get; set; } = default!;
        public DateTime Timestamp { get; set; }

    }

    public class AuditLogRequestModel
    {
        public string Action { get; set; } = default!;
        public DateTime Timestamp { get; set; }
    }
}
