using System.Net.Http.Json;
using BlazorServer.Models;

namespace BlazorServer.Services
{
    public class RutaColoniaService
    {
        private readonly HttpClient _httpClient;

        public RutaColoniaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<RutaColonia>> GetRutasColoniaAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<RutaColonia>>("api/RutaColonia") ?? new List<RutaColonia>();
        }
    }
}