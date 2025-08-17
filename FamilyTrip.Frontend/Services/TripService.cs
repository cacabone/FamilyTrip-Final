using System.Net.Http.Json;
using FamilyTrip.Frontend.Models;

namespace FamilyTrip.Frontend.Services
{
    public class TripService
    {
        private readonly HttpClient _httpClient;
        public TripService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TripDto>> GetTripsAsync()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<TripDto>>("api/Trip");
                return result ?? new List<TripDto>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"API request failed: {ex.Message}");
                return new List<TripDto>();
            }
        }

        public async Task<bool> DeleteTripAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Trip/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateTripAsync(TripDto trip)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Trip/{trip.Id}", trip);
            return response.IsSuccessStatusCode;
        }

        public class CreateTripRequest
        {
            public string Name { get; set; }
            public string Destination { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int OrganizerId { get; set; }
        }

        public async Task<bool> CreateTripAsync(TripDto trip, string destination)
        {
            // Use a named class for serialization instead of an anonymous type
            var createTrip = new CreateTripRequest
            {
                Name = trip.Name,
                Destination = destination,
                StartDate = trip.StartDate,
                EndDate = trip.EndDate,
                OrganizerId = trip.OrganizerId
            };
            var response = await _httpClient.PostAsJsonAsync("api/Trip", createTrip);
            return response.IsSuccessStatusCode;
        }
    }
}