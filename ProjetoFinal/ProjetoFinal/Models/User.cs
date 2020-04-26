using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{

    [Table("user")]
    public class User
    {
        [Column("id")]
        [Required]
        [Key]
        public int Id {get; set; }

        [Column("email")]
        [StringLength(100)]
        [Required]
        public string Email {get; set; }

        [Column("password")]
        [Required]
        public string Password { get; set; }

        public virtual ICollection<Logs> Logs { get; set; }

    }
}
