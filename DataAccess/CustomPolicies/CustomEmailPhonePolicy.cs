using Core.Model.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CustomPolicies
{

    public class CustomEmailPhonePolicy : UserValidator<User>
    {
        public async override Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            IdentityResult result = await base.ValidateAsync(manager, user);
            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

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
                    Description = "Please use another phone number" //mesajı sonra düzeltiriz
                };
                errors.Add(error);
            }
            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }

}
