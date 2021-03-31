using KNU.RS.Portal.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace KNU.RS.Portal.Services.EmailSender
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailingConfiguration config;
        private readonly ISendGridClient sendGridClient;

        public EmailSender(IOptions<EmailingConfiguration> configOptions, ISendGridClient sendGridClient)
        {
            this.config = configOptions.Value;
            this.sendGridClient = sendGridClient;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(config.EmailFrom, config.TeamName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            msg.SetClickTracking(false, false);

            return sendGridClient.SendEmailAsync(msg);
        }
    }
}
