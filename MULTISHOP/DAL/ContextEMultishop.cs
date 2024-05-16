using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using MULTISHOP.Models;

namespace MULTISHOP.DAL
{
    public class ContextEMultishop : DbContext
    {
        public ContextEMultishop(DbContextOptions options ) : base( options ) { }
      
        public DbSet <Category> Categories { get; set; }
        public DbSet <Slider> Sliders { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        ((BaseEntity)entry.Entity).CreatedTime = DateTime.Now; 
                        ((BaseEntity)entry.Entity).IsDeleted = false;   
                        break;
                        

                }


            };
           
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-742DB1G;Database=EMILMULTISHOP;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
