﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAspnet.Models
{
    public class Empleado 
    {
        [Key]
        public int ID { get; set; }
        public bool isChofer { get; set; }

        public string Nombre { get; set; }
        
    }
}