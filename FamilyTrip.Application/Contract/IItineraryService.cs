using FamilyTrip.Application.DTOs.Itinerary;
using FamilyTrip.Domain.Entities;
using System.Threading.Tasks;

namespace FamilyTrip.Application.Contract
{
    public interface IItineraryService
    {
        Task<Itinerary> AddItineraryAsync(CreateItineraryDto createItineraryDto);
        Task<Itinerary> GetByIdAsync(int id);
        Task UpdateItineraryAsync(Itinerary itinerary);
        Task DeleteItineraryAsync(int id);
    }
}
