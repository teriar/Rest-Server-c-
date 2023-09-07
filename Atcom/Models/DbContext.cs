
using Atcom.Models;
using Microsoft.EntityFrameworkCore;


namespace EjercicioPractico.Models
{
    public class myDbContext : DbContext
    {
        public myDbContext(DbContextOptions<myDbContext> options):base(options) 
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pais> pais { get; set; }

       
    }
}



//namespace Atcom.Models