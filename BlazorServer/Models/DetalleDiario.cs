using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServer.Models
{
    public class DetalleDiario
    {
        public int ID { get; set; } 

        public DateTime Fecha_orden { get; set; } = DateTime.Now;
        public DateTime Fecha_Inicio { get; set; } = DateTime.Now;
        public DateTime Fecha_TerminoEstimado { get; set; } = DateTime.Now.AddDays(1);
        public DateTime Fecha_TerminoReal { get; set; } = DateTime.Now.AddDays(1);

        
        public int ID_Unidad { get; set; }


        public Unidad? Unidad { get; set; }
        public int ID_Ruta { get; set; }

        public Ruta? Ruta { get; set; }
        public ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();


        public decimal? CantidadBasuraKg { get; set; } = 0;
        public int NumeroTurno { get; set; }

        public string? Puches { get; set; } = string.Empty;
        public string? Observaciones { get; set; } = string.Empty;
        public decimal? km_Recorridos { get; set; } = decimal.Zero;

        public decimal? Diesel_inicio { get; set; } = decimal.Zero;
        public decimal? Diesel_Recargado { get; set; } = decimal.Zero;
        public decimal? Diesel_Final { get; set; } = decimal.Zero;
        public decimal? CapacidadDiesel { get; set; } = decimal.Zero;
        public decimal? Autonomia { get; set; } = decimal.Zero;
    }
}
