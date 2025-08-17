using System.Net.Http.Json;
using FamilyTrip.Frontend.Models;

namespace FamilyTrip.Frontend.Services
{
    public class FamilyService
    {
        private readonly HttpClient _httpClient;
        public FamilyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FamilyDto>> GetFamiliesAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<FamilyDto>>("api/Family");
                return result ?? new List<FamilyDto>();
            }
            catch (HttpRequestException ex)
            {
                // Log or handle error as needed
                // You can return an empty list or rethrow, depending on your UX
                // For now, return empty and optionally log
                Console.WriteLine($"API request failed: {ex.Message}");
                return new List<FamilyDto>();
            }
        }
    }
}