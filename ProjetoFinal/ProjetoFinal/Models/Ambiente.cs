using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal.Models
{
    [Table("ambiente")]
    public class Ambiente
    {
        [Column("id")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("ambiente")]
        [Required]
        [StringLength(100)]
        public string NomeAmbiente { get; set; }

        public virtual ICollection<Erro> Erros { get; set; }

    }
}
