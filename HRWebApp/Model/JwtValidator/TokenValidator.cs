using Core.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRWebApp.Model.JwtValidator
{
    public class TokenValidator
    {
        private readonly AppSettings appSettings;
        public TokenValidator(AppSettings appSettings)
        {
            this.appSettings = appSettings;
        }
        public string ValidateUser(string token)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            string userID = null;
            SecurityToken securityToken = null;
            try
            {
                //Check if token is valid(expire time etc.)
                tokenHandler.ValidateToken(token, new TokenValidationParameters { ValidateLifetime = true, IssuerSigningKey = new SymmetricSecurityKey(key), ValidateAudience = false, ValidateIssuer = false }, out securityToken);
                if (securityToken != null)
                {
                    userID = ((JwtSecurityToken)securityToken).Claims.Where(x => x.Type == "id").FirstOrDefault().Value;

                }
                return userID;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
