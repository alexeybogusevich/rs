using KNU.RS.DbManager.Models;
using Microsoft.EntityFrameworkCore;

namespace KNU.RS.DbManager.Connections
{
    public class AzureSqlDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<RecoveryPlan> RecoveryPlans { get; set; }
        public DbSet<StudyDetails> StudyDetails { get; set; }
        public DbSet<StudyHeader> StudyHeaders { get; set; }
        public DbSet<StudySubtype> StudySubtypes { get; set; }
        public DbSet<StudyType> StudyTypes { get; set; }
        public DbSet<Visit> Visits { get; set; }


        public AzureSqlDbContext(DbContextOptions<AzureSqlDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Admin
            modelBuilder.Entity<Admin>().ToTable(nameof(Admins))
                .HasKey(a => a.Id);

            // Clinic
            modelBuilder.Entity<Clinic>().ToTable(nameof(Clinics))
                .HasKey(e => e.Id);
            modelBuilder.Entity<Clinic>().HasOne(c => c.Department)
                .WithMany(d => d.Clinics).HasForeignKey(c => c.DepartmentId);

            // Department
            modelBuilder.Entity<Department>().ToTable(nameof(Departments))
                .HasKey(d => d.Id);

            // Doctor
            modelBuilder.Entity<Doctor>().ToTable(nameof(Doctors))
                .HasKey(d => d.Id);
            modelBuilder.Entity<Doctor>().HasOne(d => d.Clinic)
                .WithMany(c => c.Doctors).HasForeignKey(d => d.ClinicId);
            modelBuilder.Entity<Doctor>().HasOne(d => d.Qualification)
                .WithMany(q => q.Doctors).HasForeignKey(d => d.QualificationId);

            // Patient
            modelBuilder.Entity<Patient>().ToTable(nameof(Patients))
                .HasKey(p => p.Id);

            // Qualification
            modelBuilder.Entity<Qualification>().ToTable(nameof(Qualifications))
                .HasKey(q => q.Id);

            // RecoveryPlan
            modelBuilder.Entity<RecoveryPlan>().ToTable(nameof(RecoveryPlans))
                .HasKey(r => r.Id);

            // StudyDetails
            modelBuilder.Entity<StudyDetails>().ToTable(nameof(StudyDetails))
                .HasKey(s => s.Id);
            modelBuilder.Entity<StudyDetails>().HasOne(s => s.StudyHeader)
                .WithMany(s => s.StudyDetails).HasForeignKey(s => s.StudyHeaderId);
            modelBuilder.Entity<StudyDetails>().HasOne(s => s.StudySubtype)
                .WithMany(s => s.StudyDetails).HasForeignKey(s => s.StudySubtypeId);

            // StudyHeader
            modelBuilder.Entity<StudyHeader>().ToTable(nameof(StudyHeaders))
                .HasKey(s => s.Id);
            modelBuilder.Entity<StudyHeader>().HasOne(s => s.RecoveryPlan)
                .WithMany(r => r.Studies).HasForeignKey(s => s.RecoveryPlanId);
            modelBuilder.Entity<StudyHeader>().HasOne(s => s.Visit)
                .WithOne(c => c.Study).HasForeignKey<StudyHeader>(s => s.VisitId);

            // StudySubtype
            modelBuilder.Entity<StudySubtype>().ToTable(nameof(StudySubtypes))
                .HasKey(s => s.Id);
            modelBuilder.Entity<StudySubtype>().HasOne(s => s.StudyType)
                .WithMany(s => s.StudySubtypes).HasForeignKey(s => s.StudyTypeId);

            // StudyType
            modelBuilder.Entity<StudyType>().ToTable(nameof(StudyTypes))
                .HasKey(s => s.Id);

            // Visit
            modelBuilder.Entity<Visit>().ToTable(nameof(Visits))
                .HasKey(v => v.Id);
            modelBuilder.Entity<Visit>().HasOne(v => v.Patient)
                .WithMany(p => p.Visits).HasForeignKey(v => v.PatientId);
            modelBuilder.Entity<Visit>().HasOne(v => v.Doctor)
                .WithMany(d => d.Visits).HasForeignKey(v => v.DoctorId);
        }
    }
}
 