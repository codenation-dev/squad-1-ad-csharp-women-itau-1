using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.DTOs
{
    public class EsqueciSenhaDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }
    }
}
