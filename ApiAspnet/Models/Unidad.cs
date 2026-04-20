using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAspnet.Models
{
    public class Unidad
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        // 1. Esta es la columna que guarda el número (1, 2, 3...)
        public int ID_TipoUnidad { get; set; }

        // 2. Esta es la "Llave Foránea" que conecta con el objeto Tipo_Unidad
        [ForeignKey("ID_TipoUnidad")]
        public Tipo_Unidad? TipoUnidad { get; set; }
    }
}
