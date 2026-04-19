﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServer.Models
{
    public class Empleado 
    {
        public int ID { get; set; }
        public bool isChofer { get; set; }

        public string Nombre { get; set; }
        
    }
}