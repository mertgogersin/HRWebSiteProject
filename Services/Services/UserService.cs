using Core.EmailSenderManager;
using Core.Entities;
using Core.Enums;
using Core.Model.Authentication;
using Core.Services;
using Core.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly Admin admin;
        UserManager<User> userManager;
        SignInManager<User> signInManager;

        public UserService(IUnitOfWork unitOfWork, IOptions<Admin> admin, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.unitOfWork = unitOfWork;
            this.admin = admin.Value;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<bool> LoginAsync(string email, string password, LoginType type)
        {

            bool check = false;
            switch (type)
            {
                case LoginType.Admin:
                    if (admin.Email == email && admin.Password == password)
                    {
                        check = true;
                    }
                    break;
                case LoginType.User:
                    User loggedInUser = await userManager.FindByEmailAsync(email);
                    if (loggedInUser != null)
                    {
                        if (userManager.PasswordHasher.VerifyHashedPassword(loggedInUser, loggedInUser.PasswordHash, password) != PasswordVerificationResult.Failed)
                        {
                            check = true;
                        }
                    }
                    break;
            }
            return await Task.FromResult(check);
        }
        public async Task<List<string>> RegisterEmployerAsync(User user, string password)
        {
            IEnumerable<User> users = await unitOfWork.Users.GetAllAsync();
            List<string> errors = new List<string>();
            
            User checkEmail = await userManager.FindByEmailAsync(user.Email);
            if (checkEmail != null && checkEmail.Email.EndsWith("@gmail.com")) { errors.Add("Please use another email."); }

            User checkPhone = await unitOfWork.Users.GetUserByPhoneNumberAsync(user.PhoneNumber);
            if (checkPhone != null) { errors.Add("Please use another phone number."); }

            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded && errors.Count == 0)
            {             
                return null; //hatasız
            }
            foreach (var error in result.Errors)
            {
                errors.Add(error.Description);
            }
            await unitOfWork.CommitAsync();
               
            return errors;

        }

        public async Task ActivateUserAsync(Guid userID)
        {
            User userToActivate = await unitOfWork.Users.GetByIDAsync(userID);
            userToActivate.IsActive = true;
            await userManager.AddToRoleAsync(userToActivate, "Employer");
            unitOfWork.Users.Update(userToActivate);
            await unitOfWork.CommitAsync();
        }
        private void SetPassiveAllLinkedUsers(Guid companyID)
        {
            List<User> users = (List<User>)unitOfWork.Users.ListAsync(m => m.CompanyID == companyID);
            foreach (User item in users)
            {
                item.IsActive = false;
            }
        }

        public async Task SetUserToPassiveAsync(Guid userID)
        {

            User userToPassive = await unitOfWork.Users.GetByIDAsync(userID);
            List<string> roles = (List<string>)await userManager.GetRolesAsync(userToPassive);
            foreach (string item in roles)
            {
                if (item == "Employer")
                {
                    SetPassiveAllLinkedUsers(userToPassive.CompanyID);
                }
            }
            userToPassive.IsActive = false;
            await unitOfWork.CommitAsync();
        }

        public async Task SendEmailToUserAsync(string email, EmailLinkType type, string content = "", string link = "")
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
                    case EmailLinkType.Register:
                        emailContent = "Account Activation Link: ";
                        emailRequest.Subject = "Activation Link";
                        break;
                    case EmailLinkType.PasswordRenewal:
                        emailContent = "Password Renewal Link: ";
                        emailRequest.Subject = "Password Renewal";
                        break;
                    case EmailLinkType.Debit:
                        emailContent = content;
                        break;
                    case EmailLinkType.OffDay:
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
