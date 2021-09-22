using Core.EmailSenderManager;
using Core.Repositories;
using DataAccess.Context;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        HRContext context;
        private readonly EmailSettings emailSettings;
        public EmailRepository(HRContext context, EmailSettings emailSettings)
        {
            this.context = context;
            this.emailSettings = emailSettings;
        }

        public async Task SendMailToUser(EmailRequest emailRequest)
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
