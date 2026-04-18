using System.Net.Http.Json;
using BlazorServer.Models;

namespace BlazorServer.Services
{
    public class TipoUnidadService
    {
        private readonly HttpClient _httpClient;

        public TipoUnidadService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TipoUnidad>> GetTiposAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TipoUnidad>>("api/TipoUnidad") ?? new List<TipoUnidad>();
        }
    }
}