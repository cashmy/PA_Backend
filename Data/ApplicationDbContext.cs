using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PA_Backend.Configuration;
using PA_Backend.Models;
using System;

namespace PA_Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<CPTCode> CPTCodes { get; set; }
        public DbSet<DiagnosisCode> DiagnosisCodes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<NoteType> NoteTypes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PlaceOfService> PlacesOfServices { get; set; }
        public DbSet<PriorAuth> PriorAuths { get; set; }
        public DbSet<PACPTCode> PACPTCodes { get; set; }
        public DbSet<PADiagCode> PADiagCodes { get; set; }
        public DbSet<PANote> PANotes { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Treatment> TreatmentClass { get; set; }
        //public DbSet<User> Users { get; set; }

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
            modelBuilder.Entity<Carrier>()
                .Property(c => c.CarrierPARequired)
                .HasDefaultValue(true);
            modelBuilder.Entity<Carrier>()
                .HasData(
                    new Carrier
                    {
                        CarrierId = 1,
                        CarrierName = "Forward Health",
                        CarrierShortName = "EDS",
                        CarrierContactName = "Jane Doe",
                        CarrierContactEmail = "",
                        CarrierContactPhone = "(800) 555-1212",
                        CarrierProviderPhone = "(800) 555-1212",
                        CarrierNotes = "",
                        CarrierClass = "MD",
                        CarrierPARequired = true
                    },
                    new Carrier
                    {
                        CarrierId = 2,
                        CarrierName = "United Health Care",
                        CarrierShortName = "UHC",
                        CarrierContactName = "",
                        CarrierContactEmail = "",
                        CarrierContactPhone = "",
                        CarrierProviderPhone = "",
                        CarrierNotes = "",
                        CarrierClass ="CO",
                        CarrierPARequired = false
                    }
                    );
            modelBuilder.Entity<Clinic>()
                .HasData(
                    new Clinic {
                        ClinicId = 1,
                        ClinicName = "The Playroom, Inc", 
                        ClinicAddress1 = "123 Any Street",
                        ClinicAddress2 = "",
                        ClinicCity = "Mt Pleasant",
                        ClinicState = "WI",
                        ClinicZip = "53406",
                        ClinicPhone = "(262) 555-1212",
                        ClinicNPI = "1144664293",
                        ClinicIsAGroup = true
                    },
                    new Clinic
                    {
                        ClinicId = 2,
                        ClinicName = "Xaris, Inc",
                        ClinicAddress1 = "123 Any Street",
                        ClinicAddress2 = "",
                        ClinicCity = "Mt Pleasant",
                        ClinicState = "WI",
                        ClinicZip = "53406",
                        ClinicPhone = "(262) 555-1212",
                        ClinicNPI = "1891048211",
                        ClinicIsAGroup = false
                    }
                    );
            modelBuilder.Entity<CPTCode>()
            .HasData(
                new CPTCode { CPTCodeId = 92507, CPTDescription = "Treatment of speech, language, voice, communication, and/or auditory processing disorder." },
                new CPTCode { CPTCodeId = 97129, CPTDescription = "Therapeutic interventions that focus on cognitive function (e.g., attention, memory, reasoning, executive function, problem-solving and/or pragmatic functioning) and compensatory strategies to manage the performance of an activity (e.g., managing time or schedules, initiating, organizing and sequencing tasks), direct (one-on-one) patient contact; initial 15 minutes" },
                new CPTCode { CPTCodeId = 97130, CPTDescription = "Each additional 15 minutes. Code 97130 is an add-on code. It will need to be billed in addition to 97129 whenever more than one 15-minute unit is performed. Code 97129 will only ever be billed once per visit. Code 91730 will never be billed alone." },
                new CPTCode { CPTCodeId = 97110, CPTDescription = "Therapeutic exercises to develop strength, endurance, range of motion and flexibility." }
            );
            modelBuilder.Entity<DiagnosisCode>();
            modelBuilder.Entity<Message>().HasKey(ms => new { ms.UserId, ms.MessageId });
            modelBuilder.Entity<NoteType>().HasData(new { NoteTypeId = 1, NoteTypeName = "General"});
            modelBuilder.Entity<Patient>()
                .Property(p => p.PatientHaveIEP)
                .HasDefaultValue(false);
            modelBuilder.Entity<Patient>()
                .Property(p => p.PatientInABA)
                .HasDefaultValue(false);
            modelBuilder.Entity<Patient>()
                .Property(p => p.PatientInactive)
                .HasDefaultValue(false);
            modelBuilder.Entity<Patient>()
                .HasData(
                    new Patient
                    {
                        PatientId = 1,
                        PatientFirstName = "Johnny",
                        PatientLastName = "Quest",
                        PatientDOB = new DateTime(1965-07-15),
                        PatientHaveIEP = true,
                        PatientInABA = true,
                        PatientClass = "CO",
                        PatientNotes = "An adventerous boy!",
                        PatientInactive = false
                    }
                );
            modelBuilder.Entity<PlaceOfService>()
                .HasData(
                    new PlaceOfService { PlaceOfServiceCode = "02", PlaceOfServiceDesc = "Telehealth" },
                    new PlaceOfService { PlaceOfServiceCode = "03", PlaceOfServiceDesc = "School" },
                    new PlaceOfService { PlaceOfServiceCode = "11", PlaceOfServiceDesc = "Office" },
                    new PlaceOfService { PlaceOfServiceCode = "12", PlaceOfServiceDesc = "Home" }
                    );
            modelBuilder.Entity<PriorAuth>()
                .Property(p => p.PACarrierPosition)
                .HasDefaultValue("P"); // P=Primary, S=Secondary, T=Tertiary
            modelBuilder.Entity<PriorAuth>()
                .Property(p => p.PAArchived)
                .HasDefaultValue(false);
            modelBuilder.Entity<PriorAuth>()
                .Property(p => p.PAExpireWarnNotification)
                .HasDefaultValue(false);
            modelBuilder.Entity<PriorAuth>()
                .Property(p => p.PAExpiredNotification)
                .HasDefaultValue(false);
            modelBuilder.Entity<PACPTCode>().HasKey(pc => new { pc.PARecordId, pc.PACPTId });
            modelBuilder.Entity<PADiagCode>().HasKey(pd => new { pd.PARecordId, pd.PADiagId });
            modelBuilder.Entity<PANote>().HasKey(pn => new { pn.PARecordId, pn.PANoteId });


            modelBuilder.Entity<Provider>()
                .Property(p => p.ProviderRcvEmails)
                .HasDefaultValue(false);
            modelBuilder.Entity<Provider>()
                .Property(p => p.ProviderRcvNotifications)
                .HasDefaultValue(false);
            modelBuilder.Entity<Provider>()
                .Property(p => p.ProviderInactive)
                .HasDefaultValue(false);
            modelBuilder.Entity<Provider>()
                .HasData(
                    new Provider { 
                        ProviderId = 1,
                        ProviderFirstName = "Julie",
                        ProviderLastName = "Fitzgerald",
                        ProviderEmail = "julie@prtherapy123.com",
                        ProviderRcvEmails = true,
                        ProviderRcvNotifications = true,
                        ProviderPhone = "",
                        ProviderNPI = "1234567890",
                        ProviderTaxonomy = "",
                        AssignedStaffUserId = null,
                        ProviderNotes = "",
                        ProviderInactive = false,
                    }
                );
            modelBuilder.Entity<Status>()
                .Property(s => s.DisplayOnSummary)
                .HasDefaultValue(false);
            modelBuilder.Entity<Status>()
                .Property(s => s.StatusTextColor)
                .HasDefaultValue("#ffffff");
            modelBuilder.Entity<Status>()
                .HasData(
                    new Status { StatusId = 1, StatusName = "Approved", StatusColor = "Green" },
                    new Status { StatusId = 2, StatusName = "Working", StatusColor = "Red", DisplayOnSummary = true },
                    new Status { StatusId = 3, StatusName = "Expired", StatusColor = "DarkRed", DisplayOnSummary = true }
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
