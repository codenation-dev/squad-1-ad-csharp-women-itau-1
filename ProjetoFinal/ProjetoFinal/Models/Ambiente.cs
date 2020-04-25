using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{
    public class Ambiente
    {
        [Column("id")]
        [Required]
        [Key]
        public int Id { get; set; }

        [Column("ambiente")]
        [Required]
        [StringLength(100)]
        public string NomeAmbiente { get; set; }

        public virtual ICollection<Erro> Erros { get; set; }
    }
}
