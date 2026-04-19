using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServer.Models
{
    public class Tipo_Unidad
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public decimal LtrsDieselTanque { get; set; }

    }
}
