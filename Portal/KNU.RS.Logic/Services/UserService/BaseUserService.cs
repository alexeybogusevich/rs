using KNU.RS.Data.Context;
using KNU.RS.Data.Models;
using KNU.RS.Logic.Converters;
using KNU.RS.Logic.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.UserService
{
    public class BaseUserService : IUserService
    {
        private readonly ApplicationContext context;
        private readonly UserManager<User> userManager;

        public BaseUserService(ApplicationContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));
        }

        public async Task<FooterInfo> GetFooterAsync(Guid id)
        {
            return await context.Users
                .Where(u => u.Id.Equals(id))
                .Select(u => UserConverter.ConvertFooter(u))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<string>> GetRolesAsync(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            return await userManager.GetRolesAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));
            await userManager.DeleteAsync(user);
        }
    }
}
