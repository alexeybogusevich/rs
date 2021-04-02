using KNU.RS.Logic.Models.User;
using System;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.UserService
{
    internal interface IUserService
    {
        Task<FooterInfo> GetFooterAsync(Guid id);
    }
}