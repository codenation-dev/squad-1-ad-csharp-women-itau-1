using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.DTOs
{
    public class ErroDTO
    {
        public int Id { get; set; }

        [Required]
        public int NivelId { get; set; }

        [Required]
        public int EventoId { get; set; }

        [Required]
        public int AmbienteId { get; set; }

        [Required]
        public string Ip { get; set; }

        [Required]
        public string Titulo { get; set; }
        
        [Required]
        public string Descricoes { get; set; }
        
        [Required]
        public DateTime Data { get; set; }

        [Required]
        public string Coletado { get; set; }

        [Required]
        public bool Arquivado { get; set; }
    }
}
