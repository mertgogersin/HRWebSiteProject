using Core.Enums;
using Core.Model.Authentication;
using Core.Services;
using Core.Settings;
using Core.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace HRWebApp.Service.Concretes
{
    public class EmailService : IEmailService
    {
        private readonly IUnitOfWork unitOfWork;
        UserManager<User> userManager;
        public EmailService(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }

        public async Task SendEmailToUserAsync(string email, EmailType type, string content = "", string link = "")
        {
            User user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                EmailRequest emailRequest = new EmailRequest();
                emailRequest.ToEmail = user.Email;
                string emailContent = string.Empty;
                emailRequest.Subject = "Notification Mail";
                switch (type)
                {
                    case EmailType.Register:
                        emailContent = "Account Activation Link: ";
                        emailRequest.Subject = "Activation Link";
                        break;
                    case EmailType.PasswordRenewal:
                        emailContent = "Password Renewal Link: ";
                        emailRequest.Subject = "Password Renewal";
                        break;
                    case EmailType.Debit:
                        emailContent = content;
                        break;
                    case EmailType.OffDay:
                        emailContent = content;
                        break;
                    case EmailType.Activated:
                        emailContent = content;
                        break;
                }

                emailRequest.Body = "<!DOCTYPE html>" +
                                "<html> " +
                                    "<body style=\"background -color:#ff7f26;text-align:center;\"> " +
                                    "<h4>" + emailContent + link + "</h4>" +
                                    "<label style=\"color:black;font-size:75px;border:3px solid;border-radius:50px;padding: 5px\">HR WebSite</label> " +
                                    "</body> " +
                                "</html>";
                await unitOfWork.Emails.SendMailToUserAsync(emailRequest);
            }
        }
    }
}
