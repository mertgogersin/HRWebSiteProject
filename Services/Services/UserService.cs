using Core.EmailSenderManager;
using Core.Entities;
using Core.Enums;
using Core.Model.Authentication;
using Core.Services;
using Core.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public User GetUserByID(Guid userID)
        {
            return unitOfWork.Users.List(m => m.Id == userID).FirstOrDefault();
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await userManager.Users.ToListAsync();
        }
        public async Task<List<string>> UpdateUserInfoAsync(User user) //custom policy hazırlanacak
        {
            List<string> errors = new List<string>();
            var result = await userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors) {errors.Add(error.Description); }
            }
            await unitOfWork.CommitAsync();
            return errors;          
        }
        public async Task<bool> LoginAsync(string email, string password, LoginType type)
        {
           
            bool check = false;
            switch (type)
            {
                case LoginType.Admin:
                    if (admin.Email == email && admin.Password == password) { check = true; }                  
                    break;
                case LoginType.User:
                    User loggedInUser = await userManager.FindByEmailAsync(email);
                    if (loggedInUser != null)
                    {
                        var result = await signInManager.PasswordSignInAsync(loggedInUser.Email, password, false, false);
                        if (result.Succeeded) { check = true; }
                       
                    }
                    break;
            }
            return await Task.FromResult(check);
        }
        public async Task<List<string>> RegisterEmployerAsync(User user, string password,Company company)
        {      
            List<string> errors = new List<string>();      
            
            user.UserName = user.Email; //username hatası aldığım için çözüm olarak unique data girmek oldu.
            await CreateCompany(company);           
            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded && errors.Count == 0) { return null; }//hatasız         
            foreach (var error in result.Errors) {errors.Add(error.Description); }   
            
            await unitOfWork.CommitAsync();             
            return errors;

        }

        private async Task CreateCompany(Company company)
        {
            await unitOfWork.Companies.AddAsync(company);
        }

        public async Task ActivateUserAsync(Guid userID)
        {
            User userToActivate = unitOfWork.Users.List(m => m.Id == userID).FirstOrDefault();
            userToActivate.IsActive = true;
            await userManager.AddToRoleAsync(userToActivate, "Employer");
            unitOfWork.Users.Update(userToActivate);
            await unitOfWork.CommitAsync();
        }
        private void SetPassiveAllLinkedUsers(Guid companyID)
        {
            List<User> users = unitOfWork.Users.List(m => m.CompanyID == companyID).ToList();
            foreach (User item in users) { item.IsActive = false; }         
        }

        public async Task SetUserToPassiveAsync(Guid userID)
        {

            User userToPassive = unitOfWork.Users.List(m => m.Id == userID).FirstOrDefault();
            List<string> roles = (List<string>)await userManager.GetRolesAsync(userToPassive);
            foreach (string item in roles)
            {
                if (item == "Employer") {  SetPassiveAllLinkedUsers(userToPassive.CompanyID);}               
            }
            userToPassive.IsActive = false;
            await unitOfWork.CommitAsync();
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

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return await userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task SetUserStatus(Guid userID, bool status)
        {
            User user = (User)unitOfWork.Users.List(x => x.Id == userID);

            if (!status) { user.IsActive = false; }
            else { user.IsActive = true; }

            await unitOfWork.CommitAsync();
        }
    }
}
