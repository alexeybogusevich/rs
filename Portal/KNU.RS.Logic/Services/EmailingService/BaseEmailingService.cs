using KNU.RS.Data.Models;
using KNU.RS.Logic.Configuration;
using KNU.RS.Logic.Enums;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace KNU.RS.Logic.Services.EmailingService
{
    public class BaseEmailingService : IEmailingService
    {
        private readonly EmailingConfiguration options;

        public BaseEmailingService(IOptions<EmailingConfiguration> options)
        {
            this.options = options.Value;
        }

        public async Task SendEmailAsync(User user, EmailType type, string password, string email = null)
        {
            var fullName = GetFullName(user);

            var message = new MimeMessage();
            message.To.Add(new MailboxAddress(fullName, email ?? user.Email));
            message.From.Add(new MailboxAddress(options.FromDisplayName, options.FromEmail));
            message.Subject = GetSubject(type);

            var templateName = $"{type}.html";

            var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\emailTemplates", templateName);
            var text = File.ReadAllText(path);

            if (!string.IsNullOrEmpty(password))
            {
                text = text.Replace("%EMAIL%", user.Email).Replace("%PASSWORD%", password);
            }

            message.Body = new TextPart(TextFormat.Html)
            {
                Text = text
            };

            await SendMessageAsync(message);
        }

        private async Task SendMessageAsync(MimeMessage message)
        {
            using var emailClient = new SmtpClient();
            emailClient.ServerCertificateValidationCallback =
                (server, certificate, certChainType, errors) => true;
            emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

            await emailClient.ConnectAsync(options.Host, int.Parse(options.Port), SecureSocketOptions.StartTlsWhenAvailable);
            await emailClient.AuthenticateAsync(options.FromEmail, options.Password);
            await emailClient.SendAsync(message);
            await emailClient.DisconnectAsync(true);
        }

        private string GetFullName(User user)
        {
            var nameBuilder = new StringBuilder();

            nameBuilder.Append(user.LastName);
            nameBuilder.Append(" ");
            nameBuilder.Append(user.FirstName);
            nameBuilder.Append(" ");
            nameBuilder.Append(user.MiddleName);

            return nameBuilder.ToString();
        }

        private string GetSubject(EmailType type)
        {
            switch (type)
            {
                case EmailType.Registration:
                    return "Дякуємо за реєстрацію";
                case EmailType.ForgotPassword:
                    return "Відновлення пароля";
                default:
                    return string.Empty;
            }
        }
    }
}
