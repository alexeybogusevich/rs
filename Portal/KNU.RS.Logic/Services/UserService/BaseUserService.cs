using KNU.RS.Data.Context;
using KNU.RS.Logic.Converters;
using KNU.RS.Logic.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.UserService
{
    public class BaseUserService : IUserService
    {
        private readonly ApplicationContext context;

        public BaseUserService(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<FooterInfo> GetFooterAsync(Guid id)
        {
            return await context.Users
                .Where(u => u.Id.Equals(id))
                .Select(u => UserConverter.Convert(u))
                .FirstOrDefaultAsync();
        }
    }
}
