using System.Net.Http.Json;
using FamilyTrip.Frontend.Models;

namespace FamilyTrip.Frontend.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<UserDto>>("api/User");
                return result ?? new List<UserDto>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"API request failed: {ex.Message}");
                return new List<UserDto>();
            }
        }

        public async Task<UserDto?> CreateUserAsync(UserDto user)
        {
            var response = await _httpClient.PostAsJsonAsync("api/User", user);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<UserDto>();
            return null;
        }

        public async Task<bool> UpdateUserAsync(UserDto user)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/User/{user.Id}", user);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/User/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}