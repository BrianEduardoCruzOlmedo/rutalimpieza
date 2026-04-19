using System.Net.Http.Json;
using BlazorServer.Models;

namespace BlazorServer.Services
{
    public class EmpleadoService
    {
        private readonly HttpClient _http;

        public EmpleadoService(HttpClient http) => _http = http;

        public async Task<List<Empleado>?> GetEmpleados()
            => await _http.GetFromJsonAsync<List<Empleado>>("api/Empleado");

        public async Task<List<Empleado>?> GetChoferes()
            => (await _http.GetFromJsonAsync<List<Empleado>>("api/Empleado")).Where(e=>e.isChofer).ToList();

        public async Task<List<Empleado>?> GetNotChoferes()
            => (await _http.GetFromJsonAsync<List<Empleado>>("api/Empleado")).Where(e => !e.isChofer).ToList();
        public async Task<List<Empleado>?> GetDisponibles(DateTime inicio, DateTime fin, bool esChofer)
        {
            // Construimos la URL con los parámetros de consulta
            return await _http.GetFromJsonAsync<List<Empleado>>(
                $"api/Empleado/Disponibles?inicio={inicio:s}&fin={fin:s}&esChofer={esChofer}");
        }
        
      
        public async Task Create(Empleado empleado) => await _http.PostAsJsonAsync("api/Empleado", empleado);

        public async Task Update(int id, Empleado empleado) => await _http.PutAsJsonAsync($"api/Empleado/{id}", empleado);

        public async Task Delete(int id) => await _http.DeleteAsync($"api/Empleado/{id}");
    }
}