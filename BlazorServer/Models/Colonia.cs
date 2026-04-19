using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlazorServer.Models
{
    
    public class Colonia
    {
        
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Habitantes { get; set; }

       
    }
}
