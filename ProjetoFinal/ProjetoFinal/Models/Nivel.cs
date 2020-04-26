using System;
using System.Collections.Generic;

namespace ProjetoFinal.Models

{
    public class Nivel
    {
        [Table("nivel")]
        public class Nivel 
        {
            [Column("id")]
            [Key]
            public int NivelId {get; set;}

            [Column("nivel")]
            [StringLength(100)]
            [Required]
            public string NivelNome {get; set }
        }
    }
}