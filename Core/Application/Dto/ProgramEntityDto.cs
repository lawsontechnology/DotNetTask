namespace ApplicationFormTask.Core.Application.Dto
{
    public class ProgramEntityDto
    {
        public string Id { get; set; }= default!;
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
    public class ProgramEntityRequestModel
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
