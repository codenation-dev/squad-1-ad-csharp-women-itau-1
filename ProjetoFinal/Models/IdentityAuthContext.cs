using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{
    public class IdentityAuthContext : IdentityDbContext<IdentityUser>
    {
        public IdentityAuthContext(DbContextOptions<IdentityAuthContext> options) : base(options)
        {

        }

    }
}
