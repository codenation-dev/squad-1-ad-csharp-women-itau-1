using ProjetoFinal.Models;
using System.Threading.Tasks;

namespace ProjetoFinal.Interfaces
{
    public interface IEmailServices
    {
        Task<EmailResponse> SendEmailBySendGridAsync(string email, string assunto, string mensagem);
    }
}