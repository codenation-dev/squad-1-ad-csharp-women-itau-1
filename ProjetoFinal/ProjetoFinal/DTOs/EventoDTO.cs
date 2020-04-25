using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.DTOs
{
    public class EventoDTO
    {
        public int Id { get; set; }

        [Required]
        public int Eventos { get; set; }
    }
}
