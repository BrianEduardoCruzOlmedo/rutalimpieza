using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlazorServer.Models
{
   

    public class Chofer
    {
        [Key]
        public int id_chofer { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }

    

   
}
