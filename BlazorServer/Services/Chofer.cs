using System.Net.Http.Json;
using BlazorServer.Models;

namespace BlazorServer.Services
{
    public class ChoferService
    {
        private readonly HttpClient _httpClient;

        public ChoferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Chofer>> GetChoferesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Chofer>>("api/Chofer") ?? new List<Chofer>();
        }
    }
}