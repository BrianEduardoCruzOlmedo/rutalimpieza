namespace BlazorServer.Models
{
    public class RutaColonia
    {
        public int IdRegistro { get; set; }
        public int IdRuta { get; set; }
        public string NombreColonia { get; set; }
        public int Habitantes { get; set; }
        public double PorcentajeAportacion { get; set; } // Valor relativo de la colonia
    }

}
