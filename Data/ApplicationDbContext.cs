using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PA_Backend.Configuration;
using PA_Backend.Models;

namespace PA_Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<CPTCode> CPTCodes { get; set; }
        public DbSet<DiagnosisCode> DiagnosisCodes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Treatment> TreatmentClass { get; set; }
        public DbSet<PlaceOfService> PlacesOfServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=eCommerce;Trusted_");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RolesConfiguration());
            modelBuilder.Entity<CPTCode>()
            .HasData(
                new CPTCode { CPTCodeId = 92507, CPTDescription = "Treatment of speech, language, voice, communication, and/or auditory processing disorder." },
                new CPTCode { CPTCodeId = 97129, CPTDescription = "Therapeutic interventions that focus on cognitive function (e.g., attention, memory, reasoning, executive function, problem-solving and/or pragmatic functioning) and compensatory strategies to manage the performance of an activity (e.g., managing time or schedules, initiating, organizing and sequencing tasks), direct (one-on-one) patient contact; initial 15 minutes" },
                new CPTCode { CPTCodeId = 97130, CPTDescription = "Each additional 15 minutes. Code 97130 is an add-on code. It will need to be billed in addition to 97129 whenever more than one 15-minute unit is performed. Code 97129 will only ever be billed once per visit. Code 91730 will never be billed alone." },
                new CPTCode { CPTCodeId = 97110, CPTDescription = "Therapeutic exercises to develop strength, endurance, range of motion and flexibility." }
            );
            modelBuilder.Entity<DiagnosisCode>();
            modelBuilder.Entity<Status>()
                .Property(s => s.DisplayOnSummary)
                .HasDefaultValue(false);
            modelBuilder.Entity<Status>()
                .HasData(
                    new Status { StatusId = 1, StatusName = "Approved", StatusColor = "Green" },
                    new Status { StatusId = 2, StatusName = "Working", StatusColor = "Red", DisplayOnSummary = true },
                    new Status { StatusId = 3, StatusName = "Expired", StatusColor = "DarkRed", DisplayOnSummary = true }
                    );
            modelBuilder.Entity<PlaceOfService>()
                .HasData(
                    new PlaceOfService { PlaceOfServiceCode = "02", PlaceOfServiceDesc = "Telehealth" },
                    new PlaceOfService { PlaceOfServiceCode = "03", PlaceOfServiceDesc = "School" },
                    new PlaceOfService { PlaceOfServiceCode = "11", PlaceOfServiceDesc = "Office" },
                    new PlaceOfService { PlaceOfServiceCode = "12", PlaceOfServiceDesc = "Home" }
                    );
            modelBuilder.Entity<Treatment>()
                .HasData(
                    new Treatment { TreatmentCode = "OT", TreatmentName = "Occupational Therapy" },
                    new Treatment { TreatmentCode = "ST", TreatmentName = "Speech Therapy" },
                    new Treatment { TreatmentCode = "PT", TreatmentName = "Physical Therapy" }
                    );
        }
    }
}
