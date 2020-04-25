using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.DTO
{
    public class ErroDTO
    {
        public int Id { get; set; }

        [Required]
        public int usuario_id { get; set; }

        [Required]
        public int nivel_id { get; set; }

        [Required]
        public string titulo { get; set; }

        [Required]
        public string detalhes { get; set; }

        [Required]
        public int ambiente_id { get; set; }
        
        [Required]
        public int evento_id { get; set; }
        
        [Required]
        public DateTime data { get; set; }

        [Required]
        public string coletado { get; set; }

        [Required]
        public bool arquivado { get; set; }
    }
}
