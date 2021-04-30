using KNU.RS.Data.Extensions;
using KNU.RS.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace KNU.RS.Data.Context
{
    public class ApplicationContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorPatient> DoctorPatients { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<RecoveryDailyPlan> RecoveryDailyPlans { get; set; }
        public DbSet<StudyDetails> StudyDetails { get; set; }
        public DbSet<StudyHeader> StudyHeaders { get; set; }
        public DbSet<StudySubtype> StudySubtypes { get; set; }
        public DbSet<StudyType> StudyTypes { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Clinic>(c =>
            {
                c.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Doctor>(d =>
            {
                d.HasKey(d => d.Id);
                d.HasOne(d => d.User).WithOne(u => u.Doctor).HasForeignKey<Doctor>(d => d.UserId).OnDelete(DeleteBehavior.ClientCascade);
                d.HasOne(d => d.Clinic).WithMany(c => c.Doctors).HasForeignKey(d => d.ClinicId);
                d.HasOne(d => d.Qualification).WithMany(q => q.Doctors).HasForeignKey(d => d.QualificationId);

                d.Property(d => d.Biography).HasMaxLength(500);
                d.Property(d => d.Competencies).HasMaxLength(500);
                d.Property(d => d.Degree).HasMaxLength(100);
            });

            modelBuilder.Entity<DoctorPatient>(dp =>
            {
                dp.HasKey(dp => dp.Id);

                dp.HasOne(dp => dp.Doctor).WithMany(d => d.Patients).HasForeignKey(dp => dp.DoctorId);
                dp.HasOne(dp => dp.Patient).WithMany(d => d.Doctors).HasForeignKey(dp => dp.PatientId);
            });

            modelBuilder.Entity<Education>(e =>
            {
                e.HasKey(e => e.Id);
                e.HasOne(e => e.Doctor).WithMany(d => d.Educations).HasForeignKey(e => e.DoctorId);
            });

            modelBuilder.Entity<Patient>(p =>
            {
                p.HasKey(p => p.Id);
                p.HasOne(d => d.User).WithOne(u => u.Patient).HasForeignKey<Patient>(d => d.UserId);
            });

            modelBuilder.Entity<Qualification>(q =>
            {
                q.HasKey(q => q.Id);
            });

            modelBuilder.Entity<RecoveryDailyPlan>(rp =>
            {
                rp.HasKey(r => r.Id);
                rp.HasOne(r => r.DoctorPatient).WithMany(p => p.RecoveryDailyPlans).HasForeignKey(r => r.DoctorPatientId);
            });

            modelBuilder.Entity<StudyDetails>(sd =>
            {
                sd.HasKey(s => s.Id);

                sd.HasOne(s => s.StudyHeader).WithMany(s => s.StudyDetails).HasForeignKey(s => s.StudyHeaderId);
                sd.HasOne(s => s.StudySubtype).WithMany(s => s.StudyDetails).HasForeignKey(s => s.StudySubtypeId);
            });

            modelBuilder.Entity<StudyHeader>(sh =>
            {
                sh.HasKey(s => s.Id);
                sh.HasOne(s => s.DoctorPatient).WithMany(r => r.StudyHeaders).HasForeignKey(s => s.DoctorPatientId);
            });

            modelBuilder.Entity<StudySubtype>(ss =>
            {
                ss.HasKey(s => s.Id);
                ss.Property(s => s.SerialNumber).ValueGeneratedOnAdd();
                ss.HasOne(s => s.StudyType).WithMany(s => s.StudySubtypes).HasForeignKey(s => s.StudyTypeId);
            });

            modelBuilder.Entity<StudyType>(st =>
            {
                st.HasKey(s => s.Id);
            });

            modelBuilder.Seed();
        }
    }
}
