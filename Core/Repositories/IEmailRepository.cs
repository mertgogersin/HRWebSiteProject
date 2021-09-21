using Core.EmailSenderManager;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IEmailRepository
    {
        Task SendMailToUser(EmailRequest emailRequest);
    }
}
