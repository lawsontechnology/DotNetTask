using ApplicationFormTask.Core.Domain.Enum;

namespace ApplicationFormTask.Core.Domain.Entities
{
    public class PersonalInformation : AuditableEntities
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Nationality { get; set; } = default!;
        public string CurrentResidence { get; set; } = default!;
        public string IDNumber { get; set; } = default!;
        public DateOnly DOB { get; set; } 
        public Gender Gender { get; set; }
        public QuestionType QuestionTypeToAnswer { get; set; }
    }
}
