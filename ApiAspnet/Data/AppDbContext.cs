using ApiAspnet.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApiAspnet.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RutaDetalleColonia>()
                .HasKey(rd => new { rd.ID_Ruta, rd.ID_Colonia }); // Llave primaria compuesta

            modelBuilder.Entity<RutaDetalleColonia>()
                .HasOne(rd => rd.Ruta)
                .WithMany(r => r.CoberturaColonias)
                .HasForeignKey(rd => rd.ID_Ruta);

            modelBuilder.Entity<RutaDetalleColonia>()
                .HasOne(rd => rd.Colonia)
                .WithMany() // Una colonia puede estar en muchos detalles
                .HasForeignKey(rd => rd.ID_Colonia);
        }
        public DbSet<DetalleDiario> Folios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Tipo_Unidad> Tipos_Unidades { get; set; }
        public DbSet<Unidad> Unidades { get; set; }
        public DbSet<Colonia> Colonias { get; set; }
        public DbSet<Ruta> Rutas { get; set; } 

    }
}
