﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlazorServer.Models
{
    public class RutaDetalleColonia
    {

        public int ID_Ruta { get; set; }

        [JsonIgnore]
        public Ruta? Ruta { get; set; }

        public int ID_Colonia { get; set; }
        [JsonIgnore]
        public Colonia? Colonia { get; set; }
        public int PorcentajeAtendidos { get; set; }

    }
    public class Ruta
    {

        public int ID { get; set; }
        public string Nombre { get; set; } // Ejemplo: "Ruta Zona Norte - Sector 1"
        public decimal KM_Estimados { get; set; }

        public ICollection<RutaDetalleColonia> CoberturaColonias { get; set; } = new List<RutaDetalleColonia>();
    }
}
