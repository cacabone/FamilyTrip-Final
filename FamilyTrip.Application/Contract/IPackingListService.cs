using FamilyTrip.Application.DTOs.PackingList;
using FamilyTrip.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FamilyTrip.Application.Contract
{
    public interface IPackingListService
    {
        Task<IEnumerable<PackingItem>> GetAllAsync();
        Task<PackingItem> GetByIdAsync(int id);
        Task<PackingItem> AddAsync(PackingItem item);
        Task<PackingItem> UpdateAsync(PackingItem item);
        Task<bool> DeleteAsync(int id);
        Task AddPackingItemAsync(CreatePackingItemDto dto);
        Task<PackingListDto> CreatePackingListAsync(CreatePackingListDto dto);
        Task<PackingListDto> GetPackingListByIdAsync(int id);
        Task<IEnumerable<PackingListDto>> GetAllPackingListsAsync();
        Task UpdatePackingListAsync(PackingList packingList);
        Task DeletePackingListAsync(int id);
    }
}
