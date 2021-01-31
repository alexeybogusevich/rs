using KNU.RS.DbManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace KNU.RS.DbManager.Connections
{
    public class AzureSqlDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DoctorProfile> DoctorProfiles { get; set; }
        public DbSet<PatientProfile> PatientProfiles { get; set; }
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
            base.OnModelCreating(modelBuilder);

            // Clinic
            modelBuilder.Entity<Clinic>(c =>
            {
                c.HasKey(e => e.Id);

                c.HasOne(c => c.Department).WithMany(d => d.Clinics)
                    .HasForeignKey(c => c.DepartmentId);

                c.ToTable(nameof(Clinics));
            });

            // Department
            modelBuilder.Entity<Department>(d =>
            {
                d.HasKey(d => d.Id);
                d.ToTable(nameof(Departments));
            });

            // DoctorProfile
            modelBuilder.Entity<DoctorProfile>(dp =>
            {
                dp.HasKey(d => d.Id);

                dp.HasOne(d => d.User).WithOne()
                    .HasForeignKey<DoctorProfile>(d => d.UserId);
                dp.HasOne(d => d.Clinic).WithMany(c => c.Doctors)
                    .HasForeignKey(d => d.ClinicId);
                dp.HasOne(d => d.Qualification).WithMany(q => q.Doctors)
                    .HasForeignKey(d => d.QualificationId);

                dp.ToTable(nameof(DoctorProfiles));
            });

            // PatientProfile
            modelBuilder.Entity<PatientProfile>(p =>
            {
                p.HasKey(p => p.Id);
                p.ToTable(nameof(PatientProfiles));
            });

            // Qualification
            modelBuilder.Entity<Qualification>(q =>
            {
                q.HasKey(q => q.Id);
                q.ToTable(nameof(Qualifications));
            });

            // RecoveryPlan
            modelBuilder.Entity<RecoveryPlan>(rp =>
            {
                rp.HasKey(r => r.Id);
                rp.ToTable(nameof(RecoveryPlans));
            });

            // StudyDetails
            modelBuilder.Entity<StudyDetails>(sd =>
            {
                sd.HasKey(s => s.Id);

                sd.HasOne(s => s.StudyHeader).WithMany(s => s.StudyDetails)
                    .HasForeignKey(s => s.StudyHeaderId);
                sd.HasOne(s => s.StudySubtype).WithMany(s => s.StudyDetails)
                    .HasForeignKey(s => s.StudySubtypeId);

                sd.ToTable(nameof(StudyDetails));
            });

            // StudyHeader
            modelBuilder.Entity<StudyHeader>(sh =>
            {
                sh.HasKey(s => s.Id);

                sh.HasOne(s => s.RecoveryPlan).WithMany(r => r.Studies)
                    .HasForeignKey(s => s.RecoveryPlanId);
                sh.HasOne(s => s.Visit).WithOne(c => c.Study)
                    .HasForeignKey<StudyHeader>(s => s.VisitId);

                sh.ToTable(nameof(StudyHeaders));
            });

            // StudySubtype
            modelBuilder.Entity<StudySubtype>(ss =>
            {
                ss.HasKey(s => s.Id);

                ss.HasOne(s => s.StudyType).WithMany(s => s.StudySubtypes)
                    .HasForeignKey(s => s.StudyTypeId);

                ss.ToTable(nameof(StudySubtypes));
            });

            // StudyType
            modelBuilder.Entity<StudyType>(st =>
            {
                st.HasKey(s => s.Id);
                st.ToTable(nameof(StudyTypes));
            });

            // Visit
            modelBuilder.Entity<Visit>(v =>
            {
                v.HasKey(v => v.Id);

                v.HasOne(v => v.Patient).WithMany(p => p.Visits)
                    .HasForeignKey(v => v.PatientId);
                v.HasOne(v => v.Doctor).WithMany(d => d.Visits)
                    .HasForeignKey(v => v.DoctorId);

                v.ToTable(nameof(Visits));
            });
        }
    }
}
 