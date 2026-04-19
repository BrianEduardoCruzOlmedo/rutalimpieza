using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServer.Models
{
    public class Unidad
    {
        public int Id { get; set; }
        public string Nombre{ get; set; } 

        public int ID_TipoUnidad{ get; set; }
        public Tipo_Unidad? TipoUnidad { get; set; }
    }
}
