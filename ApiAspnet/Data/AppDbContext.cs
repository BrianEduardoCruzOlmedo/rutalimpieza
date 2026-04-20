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

            // Seed inicial para los tipos de unidad requeridos por el formulario
            modelBuilder.Entity<Tipo_Unidad>().HasData(
                new Tipo_Unidad { ID = 1, Nombre = "volteo", LtrsDieselTanque = 0m },
                new Tipo_Unidad { ID = 2, Nombre = "redilas 12 de marzo", LtrsDieselTanque = 0m },
                new Tipo_Unidad { ID = 3, Nombre = "compactadores trisa", LtrsDieselTanque = 0m }
            );

            // Seed de algunas unidades (números) asociados a cada tipo
            modelBuilder.Entity<Unidad>().HasData(
                new Unidad { Id = 1, Nombre = "1", ID_TipoUnidad = 1 },
                new Unidad { Id = 2, Nombre = "2", ID_TipoUnidad = 1 },
                new Unidad { Id = 3, Nombre = "3", ID_TipoUnidad = 1 },

                new Unidad { Id = 4, Nombre = "4", ID_TipoUnidad = 2 },
                new Unidad { Id = 5, Nombre = "5", ID_TipoUnidad = 2 },
                new Unidad { Id = 6, Nombre = "6", ID_TipoUnidad = 2 },
                new Unidad { Id = 7, Nombre = "7", ID_TipoUnidad = 2 },

                new Unidad { Id = 8, Nombre = "8", ID_TipoUnidad = 3 },
                new Unidad { Id = 9, Nombre = "9", ID_TipoUnidad = 3 },
                new Unidad { Id = 10, Nombre = "10", ID_TipoUnidad = 3 }
            );
        }
        public DbSet<DetalleDiario> Folios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Tipo_Unidad> Tipos_Unidades { get; set; }
        public DbSet<Unidad> Unidades { get; set; }
        public DbSet<Colonia> Colonias { get; set; }
        public DbSet<Ruta> Rutas { get; set; } 

    }
}
