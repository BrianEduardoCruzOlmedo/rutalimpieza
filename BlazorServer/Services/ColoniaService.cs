using System.Net.Http.Json;
using BlazorServer.Models;

namespace BlazorServer.Services
{
    public class ColoniaService
    {
        private readonly HttpClient _http;

        public ColoniaService(HttpClient http) => _http = http;

        public async Task<List<Colonia>?> GetColonias()
            => await _http.GetFromJsonAsync<List<Colonia>>("api/Colonia");

        public async Task<Colonia?> GetById(int id)
            => await _http.GetFromJsonAsync<Colonia>($"api/Colonia/{id}");

        public async Task Create(Colonia colonia) => await _http.PostAsJsonAsync("api/Colonia", colonia);

        public async Task Update(int id, Colonia colonia) => await _http.PutAsJsonAsync($"api/Colonia/{id}", colonia);

        public async Task Delete(int id) => await _http.DeleteAsync($"api/Colonia/{id}");
    }
}