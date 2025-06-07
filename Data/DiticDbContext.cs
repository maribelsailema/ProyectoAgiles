using Microsoft.EntityFrameworkCore;
using Proyecto.Models;
using System.Collections.Generic;
namespace Proyecto.Data
{
    public class DiticDbContext : DbContext

    {
        public DiticDbContext(DbContextOptions<DiticDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}

