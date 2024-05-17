using ApplicationFormTask.Core.Domain.Entities;

namespace ApplicationFormTask.Core.Application.Dto
{
    public class ChoiceDto
    {
        public string Id { get; set; } = default!;
        public string? Description { get; set; }
        public string? DropdownQuestionId { get; set; }
        public string? MultipleQuestionId { get; set; }
    }
}
