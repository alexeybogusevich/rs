using KNU.RS.Logic.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.UserService
{
    public interface IUserService
    {
        Task<FooterInfo> GetFooterAsync(Guid id);
        Task<IEnumerable<string>> GetRolesAsync(string email);
        Task DeleteAsync(Guid id);
    }
}