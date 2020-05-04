using ProjetoFinal.Models;
using System.Threading.Tasks;

namespace ProjetoFinal.Services
{
    public interface IEmailServices
    {
        Task<EmailResponse> SendEmailBySendGridAsync(string email, string assunto, string mensagem);
    }
}