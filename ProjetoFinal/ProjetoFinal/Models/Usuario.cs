using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal.Models
{

    [Table("usuario")]
    public class Usuario
    {
        [Column("id")]
        [Required]
        [Key]
        public int Id { get; set; }

        [Column("nome")]
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Column("email")]
        [StringLength(100)]
        [Required]
        public string Email { get; set; }

        [Column("senha")]
        [Required]
        [StringLength(255)]
        public string Senha { get; set; }

    }
}
