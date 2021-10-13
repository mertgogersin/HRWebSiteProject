using Core.Settings;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IEmailRepository
    {
        Task SendMailToUserAsync(EmailRequest emailRequest);
    }
}
