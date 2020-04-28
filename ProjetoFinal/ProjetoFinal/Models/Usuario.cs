using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{

    [Table("usuario")]
    public class Usuario
    {
        [Column("id")]
        [Required]
        [Key]
        public int Id { get; set; }

        [Column("email")]
        [StringLength(100)]
        [Required]
        public string Email { get; set; }

        [Column("senha")]
        [Required]
        [StringLength(255)]
        public string Senha { get; set; }

        [Column("token")]
        [Required]
        [MaxLenght(400)]
        public string Token { get; set; }


    }
}
