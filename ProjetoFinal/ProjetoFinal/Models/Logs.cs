using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{
    [Table("logs")]
    public class Logs
    {
        [Column("id")]
        [Required]
        [Key]
        public int Id { get; set; }

        [Column("level")]
        [Required]
        public string Level { get; set; }

        [Column("titulo")]
        [Required]
        public string Titulo { get; set; }

        [Column("detalhes")]
        [StringLength(50)]
        [Required]
        public string Nickname { get; set; }

        [Column("ambiente")]
        [Required]
        public string Ambiente { get; set; }

        [Column("evento")]
        [Required]
        public int Evento { get; set; }

        [Column("data")]
        [Required]
        public DateTime Data { get; set; }

        [Column("coletado_por")]
        [StringLength(255)]
        [Required]
        public string ColetadoPor { get; set; }

        [Column("arquivado")]
        [Required]
        public bool Arquivado { get; set; }

    }
}
