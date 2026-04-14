using BlazorServer.Models;
using System.Text.Json;

namespace BlazorServer.Services
{
    public class DetalleDiarioService
    {
        //par conectarse con api de detalle diario
        private HttpClient _httpClient;
        private readonly string _urlBase = "BasedeURL";
        public DetalleDiarioService(HttpClient httpClient) {
            _httpClient = httpClient;
        }
        public async Task<List<DetalleDiario>> GetDetalleDiarios()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_urlBase}/f");
            var http = await _httpClient.GetAsync( _urlBase );
            if (http.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<List<DetalleDiario>>(http.Content.ReadAsStream()) ?? new(); //no recuerdo que segia de aqui es este es el getlist

            }
            return new();
        }
    }
    
}
