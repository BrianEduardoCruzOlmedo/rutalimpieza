using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAspnet.Models
{
    public class Unidad
    {
        [Key]
        public int Id { get; set; }
        public string Nombre{ get; set; } 

        public int ID_TipoUnidad{ get; set; }
        [ForeignKey("ID_TipoUnidad")]
        public Tipo_Unidad? TipoUnidad { get; set; }
    }
}
