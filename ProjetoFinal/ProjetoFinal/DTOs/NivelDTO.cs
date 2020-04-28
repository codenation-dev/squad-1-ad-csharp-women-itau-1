using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.DTOs
{
    public class NivelDTO
    {
        public int NivelId { get; set; }

        [Required]
        public string NivelNome { get; set; }
    }
}