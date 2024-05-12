using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MULTISHOP.Models;

namespace MULTISHOP.DAL
{
    public class ContextEMultishop : DbContext
    {
        public ContextEMultishop(DbContextOptions options ) : base( options ) { }
      
        public DbSet <Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-742DB1G;Database=EMILMULTISHOP;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
