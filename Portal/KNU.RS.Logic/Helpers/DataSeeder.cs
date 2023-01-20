using KNU.RS.Data.Context;
using KNU.RS.Data.Enums;
using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.AccountService;
using KNU.RS.Logic.Services.UserService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace KNU.RS.Logic.Helpers
{
    public static class DataSeeder
    {
        public static void Seed(this IApplicationBuilder app, ApplicationContext applicationContext)
        {
            var doctor = new DoctorRegistrationModel
            {
                FirstName = "Олексій",
                MiddleName = "Олександрович",
                LastName = "Богусевич",
                Email = "alexey.bogusevich@gmail.com",
                PhoneNumber = "+380951360156",
                Address = "Київ",
                Birthday = new DateTime(1999, 11, 22),
                Gender = Gender.Male,
                Biography = "Біографія",
                ClinicId = new Guid("a6285a67-6f1b-4adb-8de1-ffb26050c36a"),
                Degree = "Ступінь",
                Competencies = "Компетенції",
                QualificationId = new Guid("a2e2facf-6554-4bd1-9133-673e0fc45ed0"),
                Room = 101,
            };

            if (applicationContext.Users.Any(u => u.Email == doctor.Email))
            {
                return;
            }

            using var serviceScope = app.ApplicationServices.CreateScope();

            var accountService = serviceScope.ServiceProvider.GetRequiredService<IAccountService>();
            var userService = serviceScope.ServiceProvider.GetRequiredService<IUserService>();
            
            accountService.RegisterAsync(doctor).Wait();

            var user = userService.GetByEmailAsync(doctor.Email).Result;
            accountService.PromoteToAdminAsync(user.Id).Wait();
        }
    }
}