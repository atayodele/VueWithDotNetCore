using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Text;
using System.Threading.Tasks;
using VueCrudSolution.Data.ViewModel;

namespace VueCrudSolution.Shared.Notification.Email
{
    public class EmailService : IEmailService
    {
        public EmailService(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }

        private IOptions<AppSettings> _settings;

        public Task SendEmailAsync(string subject, string message, string toEmail, string name)
        {
            return Execute(_settings.Value.EmailSettings.ApiKey, subject, message, _settings.Value.EmailSettings.Email, new List<string> { toEmail }, name);
        }

        public Task SendEmailAsync(string subject, string message, string toEmail)
        {
            return Execute(_settings.Value.EmailSettings.ApiKey, subject, message, _settings.Value.EmailSettings.Email, new List<string> { toEmail });
        }


        public Task SendManyEmailAsync(string subject, string message, List<string> toEmails)
        {
            return Execute(_settings.Value.EmailSettings.ApiKey, subject, message, _settings.Value.EmailSettings.Email, toEmails);
        }

        public Task Execute(string apiKey, string subject, string message, string fromEmail, List<string> toEmails, string name = "")
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                // should be a domain other than yahoo.com, outlook.com, hotmail.com, gmail.com
                From = string.IsNullOrEmpty(name) ? new EmailAddress(fromEmail) : new EmailAddress(fromEmail, name),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            msg.SetClickTracking(false, false);
            toEmails.ForEach(email =>
            {
                msg.AddTo(new EmailAddress(email));
            });
            return client.SendEmailAsync(msg);
        }
    }
}
