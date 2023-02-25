using Microsoft.EntityFrameworkCore;
using WebApiEstadios.Entidades;

namespace WebApiEstadios
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Estadio> Estadios { get; set; }
    }
}
