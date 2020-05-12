using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{
    [Table("erro")]
    public class Erro
    {
        [Column("id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("nivel_id")]
        [Required]
        public int NivelId { get; set; }

        [ForeignKey("NivelId")]
        public virtual Nivel Niveis { get; set; }

        [Column("evento_id")]
        [Required]
        public int EventoId { get; set; }

        [Column("ambiente_id")]
        [Required]
        public int AmbienteId { get; set; }

        [ForeignKey("AmbienteId")]
        public virtual Ambiente Ambientes { get; set; }

        [Column("ip")]
        [Required]
        [MaxLength(100)]
        public string Ip { get; set; }

        [Column("titulo")]
        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Column("descricao")]
        [Required]
        [StringLength(100)]
        public string Descricoes { get; set; }

        [Column("data")]
        [Required]
        public DateTime Data { get; set; }

        [Column("coletado")]
        [Required]
        [StringLength(100)]
        public string Coletado { get; set; }

        [Column("arquivado")]
        [Required]
        public bool Arquivado { get; set; }
    }
}
