using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiAspnet.Models
{
    
    public class Colonia
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Habitantes { get; set; }

       
    }
}
