using System.Net.Http.Json;
using BlazorServer.Models;

namespace BlazorServer.Services
{
    public class TipoUnidadService
    {
        private readonly HttpClient _http;

        public TipoUnidadService(HttpClient http) => _http = http;

        public async Task<List<Tipo_Unidad>?> GetTipos()
            => await _http.GetFromJsonAsync<List<Tipo_Unidad>>("api/TipoUnidad");

        public async Task Create(Tipo_Unidad tipo) => await _http.PostAsJsonAsync("api/TipoUnidad", tipo);

        public async Task Update(int id, Tipo_Unidad tipo) => await _http.PutAsJsonAsync($"api/TipoUnidad/{id}", tipo);

        public async Task Delete(int id) => await _http.DeleteAsync($"api/TipoUnidad/{id}");
    }
}