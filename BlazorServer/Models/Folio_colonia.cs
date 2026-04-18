using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlazorServer.Models
{
    public class Folio_Detalle_Colonia
    {  
        public int id_detalle { get; set; }
        public int id_folio { get; set; }
        public int id_colonia { get; set; }
        
        public decimal Km_Limpiados_En_Este_Folio { get; set; } 
        public decimal Porcentaje_Alcanzado_En_Este_Folio { get; set; } 
    }
}
