using FamilyTrip.Application.DTOs.ItineraryItem;
using FamilyTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTrip.Application.Contract
{
    public interface IItineraryItemService
    {
        Task<IEnumerable<ItineraryItem>> GetAllAsync();
        Task<ItineraryItem> GetByIdAsync(int id);
        Task<ItineraryItem> CreateAsync(ItineraryItem item);
        Task<ItineraryItem> UpdateAsync(ItineraryItem item);
        Task<bool> DeleteAsync(int id);
        Task AddItineraryItemAsync(CreateItineraryItemDto createItineraryItemDto);
    }
}
