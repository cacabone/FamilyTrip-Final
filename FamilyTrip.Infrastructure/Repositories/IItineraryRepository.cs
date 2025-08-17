using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTrip.Domain.Entities;


namespace FamilyTrip.Infrastructure.Repository
{
    public interface IItineraryRepository
    {
        Task<IEnumerable<ItineraryItem>> GetAllAsync();
        Task<ItineraryItem> GetByIdAsync(int id);
        Task<ItineraryItem> AddAsync(ItineraryItem item);
        Task<ItineraryItem> UpdateAsync(ItineraryItem item);
        Task<bool> DeleteAsync(int id);
        Task<Itinerary> AddItineraryAsync(Itinerary itinerary);
        Task<Itinerary> GetItineraryByIdAsync(int id); // Added for GET endpoint
        Task UpdateItineraryAsync(Itinerary itinerary);
        Task DeleteItineraryAsync(int id);
    }
}
