using KNU.RS.Data.Constants;
using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace KNU.RS.Data.Seeding
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationContext>();

            var user = new User
            {
                FirstName = "Олексій",
                LastName = "Богусевич",
                Email = "alexey.bogusevich@gmail.com",
                NormalizedEmail = "ALEXEY.BOGUSEVYCH@GMAIL.COM",
                UserName = "alexey.bogusevich@gmail.com",
                NormalizedUserName = "ALEXEY.BOGUSEVYCH@GMAIL.COM",
                PhoneNumber = "+380951360156",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<User>();
                var hashed = password.HashPassword(user, "secret");
                user.PasswordHash = hashed;

                var userStore = new UserStore<User, Role, ApplicationContext, Guid>(context);
                userStore.CreateAsync(user).Wait();

                var userManager = serviceProvider.GetService<UserManager<User>>();
                userManager.AddToRolesAsync(user, new string[] { RoleName.Admin, RoleName.Doctor });

                context.SaveChanges();
            }
        }
    }
}