using Core.Repositories;
using Core.Settings;
using DataAccess.Context;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly EmailSettings emailSettings;
        public EmailRepository(EmailSettings emailSettings)
        {
            this.emailSettings = emailSettings;
        }

        public async Task SendMailToUserAsync(EmailRequest emailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(emailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(emailRequest.ToEmail));
            email.Subject = emailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = emailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailSettings.Mail, emailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
