﻿using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.Account;
using KNU.RS.Logic.Services.JWTGenerator;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.AuthenticationService
{
    public class JWTAuthenticationService : IAuthenticationService
    {
        private readonly ApplicationContext context;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IJWTGenerator jwtGenerator;

        public JWTAuthenticationService(
            ApplicationContext context, SignInManager<User> signInManager, UserManager<User> userManager,
            IJWTGenerator jwtGenerator)
        {
            this.context = context;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.jwtGenerator = jwtGenerator;
        }

        public async Task<string> AuthenticateAsync(LoginModel model)
        {
            var user = await context.Users
                .SingleOrDefaultAsync(u => u.Email.Equals(model.Email));

            if (user == null)
            {
                return null;
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password.Trim(), true);
            if (!result.Succeeded)
            {
                return null;
            }

            var userRoles = await userManager.GetRolesAsync(user);

            return jwtGenerator.CreateToken(user, userRoles);
        }
    }
}
