﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlazorServer.Model
{
    public class Colonia
    {
        [Key]
        public int id_colonia { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Habitantes { get; set; }
        public decimal Km_carretera { get; set; }

        [NotMapped] 
        public decimal Porcentaje_Limpiado { get; set; }
    }
    
}
