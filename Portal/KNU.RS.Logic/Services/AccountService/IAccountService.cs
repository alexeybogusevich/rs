﻿using KNU.RS.Logic.Models.Account;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.AccountService
{
    public interface IAccountService
    {
        Task RegisterAsync(PatientRegistrationModel model);
        Task RegisterAsync(DoctorRegistrationModel model);
        Task HandleForgotPasswordAsync(ForgotPasswordModel model);
    }
}