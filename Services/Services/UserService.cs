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
        public UserService(IUnitOfWork unitOfWork, IOptions<Admin> admin, UserManager<User> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.admin = admin.Value;
            this.userManager = userManager;
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
        public async Task<List<string>> RegisterEmployer(User user, string password)
        {
            IEnumerable<User> users = await unitOfWork.Users.GetAllAsync();
            List<string> errors = new List<string>();

            User checkEmail = await userManager.FindByEmailAsync(user.Email);
            if (checkEmail != null) { errors.Add("Please use another email."); }

            User checkPhone = await unitOfWork.Users.GetUserByPhoneNumber(user.PhoneNumber);
            if (checkPhone != null) { errors.Add("Please use another phone number."); }

            if (errors.Count == 0)
            {
                user.PasswordHash = userManager.PasswordHasher.HashPassword(user, password);
                await unitOfWork.Users.AddAsync(user);
                return null;
            }
            return errors;

        }
    }
}
