using BlazorServer.Models;

namespace BlazorServer.Services
{
    public class UnidadService
    {
        
        private readonly HttpClient _httpClient;

        public UnidadService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<Unidad>> GetUnidadesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Unidad>>("api/Unidad") ?? new List<Unidad>();
        }
        public async Task<Unidad?> GetUnidadByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Unidad>($"api/Unidad/{id}");
        }
        public async Task CreateUnidadAsync(Unidad unidad)
        {
            await _httpClient.PostAsJsonAsync("api/Unidad", unidad);
        }
        public async Task UpdateUnidadAsync(Unidad unidad){
            await _httpClient.PutAsJsonAsync($"api/Unidad/{unidad.IdUnidad}", unidad);
        }
        public async Task DeleteUnidadAsync(int id){
            await _httpClient.DeleteAsync($"api/Unidad/{id}");
        }   
    }
}
