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
                    Name = "Военный госпиталь",
                    Location = "Локация",
                    PhoneNumber = "12345"
                });

            modelBuilder.Entity<Qualification>().HasData(
                new Qualification
                {
                    Id = new Guid("35b9add3-729d-41b9-8a8c-d74681d1d526"),
                    Name = "Терапевт"
                });

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = RoleId.AdminId,
                    Name = RoleName.Admin
                },
                new Role
                {
                    Id = RoleId.DoctorId,
                    Name = RoleName.Doctor
                },
                new Role
                {
                    Id = RoleId.PatientId,
                    Name = RoleName.Patient
                });
        }
    }
}
