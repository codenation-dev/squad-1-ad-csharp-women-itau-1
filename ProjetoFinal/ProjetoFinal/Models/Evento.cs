using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{

    [Table("evento")]
    public class Evento
    {
        [Column("id")]
        [Required]
        [Key]
        public int Id { get; set; }

        [Column("evento")]
        [Required]
        [StringLength(100)]
        public int NomeEvento { get; set; }

        public virtual ICollection<Erro> Erros { get; set; }

    }
}
