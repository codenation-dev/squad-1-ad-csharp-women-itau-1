using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        [Required]
<<<<<<< Updated upstream
        public string Email { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Senha { get; set; }
=======
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }
>>>>>>> Stashed changes

        [Required]
        public string Senha { get; set; }

    }
}