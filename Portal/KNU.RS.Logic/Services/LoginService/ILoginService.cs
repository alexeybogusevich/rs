﻿using KNU.RS.Logic.Models.Account;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.LoginService
{
    public interface ILoginService
    {
        Task<bool> CheckLoginAsync(LoginModel model);
        Task LogoutAsync();
    }
}