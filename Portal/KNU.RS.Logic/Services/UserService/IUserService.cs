using KNU.RS.Logic.Models.User;
using System;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.UserService
{
    public interface IUserService
    {
        Task<FooterInfo> GetFooterAsync(Guid id);
    }
}