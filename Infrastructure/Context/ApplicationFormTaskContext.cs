using ApplicationFormTask.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationFormTask.Infrastructure.Context
{
    public class ApplicationFormTaskContext : DbContext
    {
        public ApplicationFormTaskContext(DbContextOptions<ApplicationFormTaskContext> options) : base(options) 
        { 

        }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Choice> choices { get; set; }
        public DbSet<CustomQuestion> customQuestions { get; set; }
        public DbSet<DateQuestion> dateQuestions { get; set; }
        public DbSet<DropdownQuestion> dropdownQuestions { get; set; }
        public DbSet<MultipleQuestion> multipleQuestions { get; set; }
        public DbSet<NumericQuestion> numericQuestions { get; set; }
        public DbSet<ParagraphQuestion> paragraphQuestions { get; set; }
        public DbSet<PersonalInformation> PersonalInformation { get; set; }
        public DbSet<ProgramEntity> programs { get; set; }
        public DbSet<YesOrNoQuestion> yesOrNoQuestions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Choice>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<CustomQuestion>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<DateQuestion>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<DropdownQuestion>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<MultipleQuestion>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<NumericQuestion>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<ParagraphQuestion>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<PersonalInformation>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<ProgramEntity>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<YesOrNoQuestion>()
                .HasKey(e => e.Id);
        }
     }
}
