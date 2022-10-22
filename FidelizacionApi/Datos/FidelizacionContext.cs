using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class FidelizacionContext : DbContext
    {
        public FidelizacionContext(DbContextOptions<FidelizacionContext> options) : base(options){}

        public DbSet<TipoVencimiento> TipoVencimiento { get; set; }
        public DbSet<Compania> Compania { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoVencimiento>().HasData(new TipoVencimiento[]
            {
                new TipoVencimiento { Id = 1, Tipo = "Tiempo" },
                new TipoVencimiento { Id = 2, Tipo = "Conexion" }
            });
        }

    }
}