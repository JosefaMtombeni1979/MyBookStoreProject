using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using WebApi.Authentication;
using WebApi.Models;

namespace WebApi.Service
{
    public interface IEmailService
    {
        Task SendConfirmationEmail(ApplicationUser user, UserEmailOptions userEmailOptions, string token);
    }
}