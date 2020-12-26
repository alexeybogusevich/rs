using KNU.RS.DbManager.Models;
using Microsoft.EntityFrameworkCore;

namespace KNU.RS.DbManager.Connections
{
    public class AzureSqlDbContext : DbContext
    {
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<StudyDetails> StudyDetails { get; set; }
        public DbSet<StudyHeader> StudyHeaders { get; set; }
        public DbSet<StudySubtype> StudySubtypes { get; set; }
        public DbSet<StudyType> StudyTypes { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public AzureSqlDbContext(DbContextOptions<AzureSqlDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            // Patient
            modelBuilder.Entity<Patient>().ToTable(nameof(Patients))
                .HasKey(p => p.Id);

            // Role
            modelBuilder.Entity<Role>().ToTable(nameof(Roles))
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

            // StudySubtype
            modelBuilder.Entity<StudySubtype>().ToTable(nameof(StudySubtypes))
                .HasKey(s => s.Id);
            modelBuilder.Entity<StudySubtype>().HasOne(s => s.StudyType)
                .WithMany(s => s.StudySubtypes).HasForeignKey(s => s.StudyTypeId);

            // StudyType
            modelBuilder.Entity<StudyType>().ToTable(nameof(StudyTypes))
                .HasKey(s => s.Id);

            // User
            modelBuilder.Entity<User>().ToTable(nameof(Users))
                .HasKey(u => u.Id);

            // UserRole
            modelBuilder.Entity<UserRole>().ToTable(nameof(UserRoles))
                .HasKey(u => new { u.UserId, u.RoleId } );
        }
    }
}
 