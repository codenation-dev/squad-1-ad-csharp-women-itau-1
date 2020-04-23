using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{
    public class Erro
    {
        [Column("id")]
        [Required]
        [Key]
        public int Id { get; set; }

        [Column("usuario_id")]
        [Required]
        public int usuario_id { get; set; }

        [ForeignKey("usuarioId")]
        public virtual Usuario UsuarioId { get; set; }

        [Column("nivel_id")]
        [Required]
        public int nivel_id { get; set; }

        [ForeignKey("nivelId")]
        public virtual Nivel NivelId { get; set; }

        [Column("titulo")]
        [Required]
        [StringLength(100)]
        public string titulo { get; set; }

        [Column("detalhes")]
        [Required]
        [StringLength(100)]
        public string detalhes { get; set; }

        [Column("ambiente_id")]
        [Required]
        public int ambiente_id { get; set; }

        [ForeignKey("ambienteId")]
        public virtual Ambiente AmbienteId { get; set; }

        [Column("evento_id")]
        [Required]
        public int evento_id { get; set; }

        [ForeignKey("eventoId")]
        public virtual Evento EventoId { get; set; }

        [Column("data")]
        [Required]
        public DateTime data { get; set; }

        [Column("coletado")]
        [Required]
        [StringLength(100)]
        public string coletado { get; set; }

        [Column("arquivado")]
        [Required]
        public bool arquivado { get; set; }











    }
}
