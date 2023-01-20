using KNU.RS.Data.Models;
using KNU.RS.Logic.Models.User;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.UserService
{
    public interface IUserService
    {

        Task DeleteAsync(Guid id);
        Task<User> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<FooterInfo> GetFooterAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<string>> GetRolesAsync(string email);
    }
}