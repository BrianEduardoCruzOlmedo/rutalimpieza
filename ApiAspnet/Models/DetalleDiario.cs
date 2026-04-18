using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAspnet.Models
{
    public class DetalleDiario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Folio { get; set; } // Serial automático

        public DateTime Fecha_orden { get; set; }
        public DateTime Fecha_captura { get; set; } 
        
        public int Turno { get; set; }
        
        public int id_ruta { get; set; }
        public int id_despachador { get; set; }
        public int id_chofer { get; set; }
        public int id_tipo_unidad { get; set; }
        public int id_unidadcantidad { get; set; }

        public decimal puches { get; set; }
        public decimal km_salir { get; set; }
        public decimal km_regreso { get; set; }
        
        public decimal Diesel_inicio { get; set; }
        public decimal Diesel_Final { get; set; }
        public decimal Diesel_cargado { get; set; }
        public decimal Diesel_unidad { get; set; }
    }
}
