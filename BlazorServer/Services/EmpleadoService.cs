using System.Net.Http.Json;
using BlazorServer.Models;

namespace BlazorServer.Services
{
    public class EmpleadoService
    {
        private readonly HttpClient _httpClient;

        public EmpleadoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Empleado>>("api/Empleado") ?? new List<Empleado>();
        }
    }
}