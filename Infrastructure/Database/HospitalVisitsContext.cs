using Domain;
using System.Data.Entity;
using System.Diagnostics;

namespace Infrastructure.Database
{
    public class HospitalVisitsContext : DbContext
    {
        public HospitalVisitsContext(string connectionString) : base(connectionString)
        {
            Debug.WriteLine(connectionString); // Logs the connection string to the debug output
        }

        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientVisit> PatientVisits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialization>().ToTable(nameof(Specialization));
            modelBuilder.Entity<Hospital>().ToTable(nameof(Hospital));
            modelBuilder.Entity<Doctor>().ToTable(nameof(Doctor));
            modelBuilder.Entity<Patient>().ToTable(nameof(Patient));
            modelBuilder.Entity<PatientVisit>().ToTable(nameof(PatientVisit));

            // Define primary keys
            modelBuilder.Entity<Specialization>().HasKey(s => s.Id);
            modelBuilder.Entity<Hospital>().HasKey(h => h.Id);
            modelBuilder.Entity<Doctor>().HasKey(d => d.Id);
            modelBuilder.Entity<Patient>().HasKey(p => p.Id);
            modelBuilder.Entity<PatientVisit>().HasKey(pv => pv.Id);

            // Set mandatory fields
            modelBuilder.Entity<Specialization>().Property(s => s.Name).IsRequired();
            modelBuilder.Entity<Hospital>().Property(h => h.Name).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.FirstName).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.LastName).IsRequired();
            modelBuilder.Entity<Patient>().Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<Patient>().Property(p => p.LastName).IsRequired();
            modelBuilder.Entity<PatientVisit>().Property(pv => pv.Date).IsRequired();

            // Define foreign keys and relationships
            modelBuilder.Entity<PatientVisit>()
                .HasRequired(pv => pv.Hospital)
                .WithMany(h => h.PatientVisits)
                .HasForeignKey(pv => pv.HospitalId);

            modelBuilder.Entity<PatientVisit>()
                .HasRequired(pv => pv.Patient)
                .WithMany(p => p.PatientVisits)
                .HasForeignKey(pv => pv.PatientId);

            modelBuilder.Entity<PatientVisit>()
                .HasRequired(pv => pv.Doctor)
                .WithMany(d => d.PatientVisits)
                .HasForeignKey(pv => pv.DoctorId);

            modelBuilder.Entity<PatientVisit>()
                .HasRequired(pv => pv.Specialization)
                .WithMany()
                .HasForeignKey(pv => pv.SpecializationId);

            modelBuilder.Entity<PatientVisit>()
                .HasIndex(pv => pv.HospitalId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
