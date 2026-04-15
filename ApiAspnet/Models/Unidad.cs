using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlazorServer.Models
{
    public class Unidad
    {
        [Key]
        public int id_unidad { get; set; }
        public string Nombre_Unidad { get; set; } = string.Empty;

        public int id_tipo_unidad { get; set; } 
        
        [ForeignKey("id_tipo_unidad")]
        public Tipo_Unidad? TipoUnidadInfo { get; set; }
    }
}
