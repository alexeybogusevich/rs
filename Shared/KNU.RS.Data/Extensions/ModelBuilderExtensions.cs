using KNU.RS.Data.Constants;
using KNU.RS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace KNU.RS.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinic>().HasData(
                new Clinic
                {
                    Id = new Guid("a6285a67-6f1b-4adb-8de1-ffb26050c36a"),
                    Name = "Військовий шпиталь",
                    Location = "вул. Госпітальна, 16",
                    PhoneNumber = "044 521 8413"
                });

            modelBuilder.Entity<Qualification>().HasData(
                new Qualification
                {
                    Id = new Guid("35b9add3-729d-41b9-8a8c-d74681d1d526"),
                    Name = "Лаборант"
                },
                new Qualification
                {
                    Id = new Guid("a2e2facf-6554-4bd1-9133-673e0fc45ed0"),
                    Name = "Фізіотерапевт"
                });

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = RoleId.AdminId,
                    Name = RoleName.Admin,
                    NormalizedName = RoleName.Admin.ToUpper()
                },
                new Role
                {
                    Id = RoleId.DoctorId,
                    Name = RoleName.Doctor,
                    NormalizedName = RoleName.Doctor.ToUpper()
                },
                new Role
                {
                    Id = RoleId.PatientId,
                    Name = RoleName.Patient,
                    NormalizedName = RoleName.Patient.ToUpper()
                });
        }
    }
}
