using Core.Model.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CustomPolicies
{
    public class CustomUserValidator<T> :IUserValidator<T> where T : User
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<T> manager, T user)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (!user.Email.ToLower().EndsWith("@gmail.com"))
            {
                IdentityError error = new()
                {
                    Code = "EmailValidation",
                    Description = "You can only signup with gmail accounts"
                };
                errors.Add(error);
            }
            if (user.Email.Length > 50)
            {
                IdentityError error = new()
                {
                    Code = "EmailLength",
                    Description = "Email can't be longer than 50 chars"
                };
                errors.Add(error);
            }
            if (user.PhoneNumber.Length != 11 && user.PhoneNumber.StartsWith("0"))
            {
                IdentityError error = new()
                {
                    Code = "PhoneNumberValidation",
                    Description = "Please use another phone number"
                };
                errors.Add(error);
            }
            string phoneNumber = null;
            phoneNumber = await manager.GetPhoneNumberAsync(user);
            if (phoneNumber != null)
            {
                IdentityError error = new()
                {
                    Code = "UniquePhoneNumberValidation",
                    Description = "This phone number already in use, please try another phone number"
                };
                errors.Add(error);
            }
            return await Task.FromResult(errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
