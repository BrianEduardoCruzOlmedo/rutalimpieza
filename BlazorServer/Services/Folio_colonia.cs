using System.Net.Http.Json;
using BlazorServer.Models;

namespace BlazorServer.Services
{
    public class FolioColoniaService
    {
        private readonly HttpClient _httpClient;

        public FolioColoniaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FolioColoniaService>> GetFoliosColoniaAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<FolioColoniaService>>("api/FolioColonia") ?? new List<FolioColoniaService>();
        }
    }
}