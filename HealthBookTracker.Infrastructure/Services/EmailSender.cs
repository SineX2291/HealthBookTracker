using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HealthBookTracker.Infrastructure.Services
{
    public class EmailSender(IOptions<EmailSettings> options) : IEmailSender
    {
        private readonly EmailSettings _emailSettings = options.Value;

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort)
            {
                Credentials = new NetworkCredential(_emailSettings.SmtpUser, _emailSettings.SmtpPass),
                EnableSsl = true
            };

            var mail = new MailMessage
            {
                From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            mail.To.Add(email);

            await client.SendMailAsync(mail);
        }
    }
    public class EmailSettings
    {
        public required string SmtpServer { get; set; }
        public required int SmtpPort { get; set; }
        public required string SmtpUser { get; set; }
        public required string SmtpPass { get; set; }
        public required string SenderName { get; set; }
        public required string SenderEmail { get; set; }
    }
}