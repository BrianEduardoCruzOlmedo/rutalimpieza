using BlazorServer.Models;
using System.Text.Json;

namespace BlazorServer.Services
{
    public class DetalleDiarioService
    {
        private readonly HttpClient _http;

        public DetalleDiarioService(HttpClient http) => _http = http;

        public async Task<List<DetalleDiario>?> GetFolios()
            => await _http.GetFromJsonAsync<List<DetalleDiario>>("api/DetalleDiario");

        public async Task<DetalleDiario?> Post(DetalleDiario detalle)
        {
            var response = await _http.PostAsJsonAsync("api/DetalleDiario", detalle);
            return await response.Content.ReadFromJsonAsync<DetalleDiario>();
        }

        public async Task UpdateStatus(int id, DetalleDiario detalle)
        {
            await _http.PutAsJsonAsync($"api/DetalleDiario/UpdateStatus/{id}", detalle);
        }

        public async Task Delete(int id)
        {
            await _http.DeleteAsync($"api/DetalleDiario/{id}");
        }
    }

}
