using System;
using System.ComponentModel.DataAnnotations;


namespace ProjetoFinal.DTOs
{
    public class ResetSenhaDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string UserId { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Code { get; set; }
    }
}