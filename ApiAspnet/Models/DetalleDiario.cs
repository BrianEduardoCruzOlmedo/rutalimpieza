using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAspnet.Models
{
    public class DetalleDiario
    {
        [Key]
        public int ID { get; set; } 

        public DateTime Fecha_orden { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_TerminoEstimado { get; set; }
        public DateTime Fecha_TerminoReal { get; set; }

        
        public int ID_Unidad { get; set; }


        [ForeignKey("ID_Unidad")]
        public Unidad? Unidad { get; set; }
        public int ID_Ruta { get; set; }

        [ForeignKey(nameof(ID_Ruta))]
        public Ruta? Ruta { get; set; }
        public ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();


        public decimal km_Recorridos { get; set; }
        
        public decimal Diesel_inicio { get; set; }
        public decimal Diesel_Recargado { get; set; }
        public decimal Diesel_Final { get; set; }
        public decimal CapacidadDiesel { get; set; }
        public decimal Autonomia { get; set; }
    }
}
