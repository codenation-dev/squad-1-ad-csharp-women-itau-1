using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models

{
    [Table("nivel")]
    public class Nivel 
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("nivel")]
        [StringLength(100)]
        [Required]
        public string NomeNivel { get; set; }

        public virtual ICollection<Erro> Erros { get; set; }
    }
}