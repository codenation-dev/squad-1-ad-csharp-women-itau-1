using Microsoft.AspNetCore.Identity;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{
    public class ErrorResponse
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
        public string[] Detalhes { get; set; }
        public ErrorResponse InnerException { get; set; }

        public static ErrorResponse From(Exception e)
        {
            if (e == null)
            {
                return null;
            }
            return new ErrorResponse
            {
                Codigo = e.HResult,
                Mensagem = e.Message,
                InnerException = ErrorResponse.From(e.InnerException)
            };
        }

        internal static object FromIdentity(List<IdentityError> identityErrors)
        {
            return new ErrorResponse
            {
                Codigo = 400,
                Mensagem = "Houve erro na requisição",
                Detalhes = identityErrors.Select(x => x.Description).ToArray()
            };
        }

        public static ErrorResponse FromEmail(Response response)
        {
            return new ErrorResponse
            {
                Codigo = 600,
                Mensagem = $"Não foi possível enviar e-mail, {response.StatusCode}"
            };
        }
    }
}
