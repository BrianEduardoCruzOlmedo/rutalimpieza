using BlazorServer.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApiAspnet.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Folio> Folios { get; set; }
        public DbSet<Colonia> Colonias { get; set; }
        public DbSet<Folio_Detalle_Colonia> Folio_Detalles { get; set; }
        public DbSet<Despachador> Despachadores { get; set; }
        public DbSet<Chofer> Choferes { get; set; }
        public DbSet<Tipo_Unidad> Tipos_Unidades { get; set; }
        public DbSet<Unidad> Unidades { get; set; }
        
        /// terminar el resto
    }
}
