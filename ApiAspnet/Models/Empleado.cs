using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlazorServer.Models
{
   public class Despachador
    {
        [Key]
        public int id_despachador { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

   

   
}
