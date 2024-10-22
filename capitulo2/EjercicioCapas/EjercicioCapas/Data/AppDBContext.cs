using EjercicioCapas.Bussiness.Entities;
using Microsoft.EntityFrameworkCore;

namespace EjercicioCapas.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() { }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        /*Declarando Entidades*/
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Book> Book { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql("")            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Configurando PK*/
            modelBuilder.Entity<Autor>().Property(t => t.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Book>().Property(t => t.Id).ValueGeneratedOnAdd();
           
            /*FK*/
            modelBuilder.Entity<Autor>()
                .HasMany(t => t.Books)
                .WithOne(t => t.Autor)
                .HasForeignKey(r => r.AutorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
