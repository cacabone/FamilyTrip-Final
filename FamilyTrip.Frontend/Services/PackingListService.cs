using System.Net.Http.Json;
using FamilyTrip.Frontend.Models;

namespace FamilyTrip.Frontend.Services
{
    public class PackingListService
    {
        private readonly HttpClient _httpClient;
        public PackingListService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PackingListDto>> GetPackingListsAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<PackingListDto>>("api/Packing/lists");
                return result ?? new List<PackingListDto>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"API request failed: {ex.Message}");
                return new List<PackingListDto>();
            }
        }

        public async Task<PackingListDto?> CreatePackingListAsync(PackingListDto list)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Packing/list", list);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<PackingListDto>();
            return null;
        }

        public async Task<bool> DeletePackingListAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Packing/list/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<PackingItemDto?> CreatePackingItemAsync(PackingItemDto item)
        {
            // The API expects CreatePackingItemDto at POST /api/Packing
            var createDto = new CreatePackingItemDto
            {
                Name = item.Name,
                IsPacked = item.IsPacked,
                PackingListId = item.PackingListId
            };
            var response = await _httpClient.PostAsJsonAsync("api/Packing", createDto);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<PackingItemDto>();
            return null;
        }

        public async Task<bool> DeletePackingItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Packing/item/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdatePackingItemAsync(PackingItemDto item)
        {
            // The API expects PackingItemDto at PUT /api/Packing/{id}
            var response = await _httpClient.PutAsJsonAsync($"api/Packing/{item.Id}", item);
            return response.IsSuccessStatusCode;
        }
    }

    public class CreatePackingItemDto
    {
        public string Name { get; set; }
        public bool IsPacked { get; set; }
        public int PackingListId { get; set; }
    }
}