namespace BlazorServer.Models
{
    public class DetalleDiario
    {
        public int IdFolio { get; set; }
        public DateTime FechaOrden { get; set; }
        public string Turno { get; set; }


        public int IdDespachador { get; set; }
        public int IdChofer { get; set; }
        public int IdTipoUnidad { get; set; }
        public int IdUnidad { get; set; }
        public int IdRuta { get; set; }

        public double KmSalir { get; set; }
        public double KmEntrar { get; set; }
        public string Comentarios { get; set; }
        public bool RutaTerminada { get; set; }

        public double TotalKm => KmEntrar - KmSalir;


        public double CalcularEfectividad(List<RutaColonia> coloniasDeLaRuta)
        {
            if (coloniasDeLaRuta == null || coloniasDeLaRuta.Count == 0) return 0;

            double sumaEsperada = coloniasDeLaRuta.Count * 100;
            // Aquí iría la lógica de cuántas colonias se completaron realmente
            return sumaEsperada;
        }
    }
}
