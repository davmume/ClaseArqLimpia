using MicroservicioPerros.Bussiness.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroservicioPerros.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() { }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        /*Declarando Entidades*/
        public DbSet<Dog> Dogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Configurando PK*/
            modelBuilder.Entity<Dog>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();     

            base.OnModelCreating(modelBuilder);
        }
    }
}
