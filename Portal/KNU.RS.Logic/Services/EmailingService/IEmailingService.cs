using KNU.RS.Data.Models;
using KNU.RS.Logic.Enums;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.EmailingService
{
    public interface IEmailingService
    {
        Task SendEmailAsync(User user, EmailType type, string password, string email = null);
    }
}