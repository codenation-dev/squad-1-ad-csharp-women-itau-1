using ProjetoFinal.Models;
using ProjetoFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ProjetoFinal.Interfaces;

namespace ProjetoFinal.Extensions
{
    public static class EmailServicesExtensions
    {
        // extensao IEmailServices
        public static Task<EmailResponse> SendEmailResetPasswordAsync(this IEmailServices emailServices, string email, string link)
        {
            return emailServices.SendEmailBySendGridAsync(email, "Reset Password",
                $"Por favor para resetar sua senha clique nesse link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
