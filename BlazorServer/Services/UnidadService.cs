using BlazorServer.Models;

namespace BlazorServer.Services
{
   

        public class UnidadService
        {
            private readonly HttpClient _http;

            public UnidadService(HttpClient http) => _http = http;

            public async Task<List<Unidad>?> GetUnidades()
                => await _http.GetFromJsonAsync<List<Unidad>>("api/Unidad");

            public async Task<Unidad?> GetById(int id)
                => await _http.GetFromJsonAsync<Unidad>($"api/Unidad/Read/{id}");

            public async Task<List<Unidad>?> GetDisponibles(DateTime inicio, DateTime fin)
            {
                // Usamos QueryStrings para pasar fechas
                return await _http.GetFromJsonAsync<List<Unidad>>($"api/Unidad/Disponibles?inicio={inicio:s}&fin={fin:s}");
            }

            public async Task Create(Unidad unidad)
            {
                await _http.PostAsJsonAsync("api/Unidad/Create", unidad);
            }

            public async Task Update(int id, Unidad unidad)
            {
                await _http.PutAsJsonAsync($"api/Unidad/Update/{id}", unidad);
            }

            public async Task Delete(int id)
            {
                await _http.DeleteAsync($"api/Unidad/Delete/{id}");
            }
        }
    
}
