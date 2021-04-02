using Microsoft.AspNetCore.Identity;

namespace KNU.RS.Logic.Services.PasswordService
{
    public interface IPasswordService
    {
        string GeneratePassword(PasswordOptions options);
    }
}