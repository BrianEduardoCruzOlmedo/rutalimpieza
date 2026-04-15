using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlazorServer.Models
{
    public class Tipo_Unidad
    {
        [Key]
        public int id_tipo_unidad { get; set; }
        public string Nombre_Tipo { get; set; } = string.Empty; 
    }
}
