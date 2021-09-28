﻿using Core.Entities;
using Core.Enums;
using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
   public interface IUserService
    {
        Task<List<string>> RegisterEmployerAsync(User user,string password,Company company);
        Task<bool> LoginAsync(string email, string password, LoginType type);
        Task ActivateUserAsync(Guid userID);
        Task SetUserToPassiveAsync(Guid userID);
        User GetUserByID(Guid userID);
        Task<User> GetUserByEmailAsync(string email);
        Task<string> GenerateEmailConfirmationTokenAsync(User user);
        Task SendEmailToUserAsync(string email, EmailLinkType type, string content = "", string link = "");
        Task<List<string>> UpdateUserInfoAsync(User user);
    }
}
