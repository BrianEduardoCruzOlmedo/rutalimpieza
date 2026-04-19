﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAspnet.Models
{
    public class Empleado // <-- Cambiamos Despachador por Empleado
    {
        [Key]
        public int id_empleado { get; set; } // <-- Unificamos el ID
        
        public string Nombre { get; set; } = string.Empty;
        
        // Es buena idea tener este campo para distinguir en el futuro
        public string Tipo { get; set; } = string.Empty; 
    }
}