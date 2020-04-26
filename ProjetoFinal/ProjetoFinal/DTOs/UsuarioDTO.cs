using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.DTOs
{
    public class UsuarioDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public string Token { get; set; }

    }
}