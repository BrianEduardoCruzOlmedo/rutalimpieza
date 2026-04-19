using System.Net.Http.Json;
using BlazorServer.Models;

namespace BlazorServer.Services
{
    public class RutaService
    {
        private readonly HttpClient _http;

        public RutaService(HttpClient http) => _http = http;

        public async Task<List<Ruta>?> GetRutas()
            => await _http.GetFromJsonAsync<List<Ruta>>("api/Ruta");

        public async Task Create(Ruta ruta) => await _http.PostAsJsonAsync("api/Ruta", ruta);

        public async Task Update(int id, Ruta ruta) => await _http.PutAsJsonAsync($"api/Ruta/{id}", ruta);

        public async Task Delete(int id) => await _http.DeleteAsync($"api/Ruta/{id}");
    }
}