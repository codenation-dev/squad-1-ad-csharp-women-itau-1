using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.DTOs
{
    public class AmbienteDTO
    {
        public int Id { get; set; }

        [Required]
        public string NomeAmbiente { get; set; }
    }
}
