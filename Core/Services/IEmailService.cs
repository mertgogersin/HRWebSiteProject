using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IEmailService
    {
        Task SendEmailToUserAsync(string email, EmailType type, string content = "", string link = "");
    }
}
