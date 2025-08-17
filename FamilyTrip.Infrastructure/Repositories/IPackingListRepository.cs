using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTrip.Domain.Entities;

namespace FamilyTrip.Infrastructure.Repository
{
    public interface IPackingListRepository
    {
        Task<IEnumerable<PackingItem>> GetAllAsync();
        Task<PackingItem> GetByIdAsync(int id);
        Task<PackingItem> AddAsync(PackingItem item);
        Task<PackingItem> UpdateAsync(PackingItem item);
        Task<bool> DeleteAsync(int id);
        Task<PackingList> AddPackingListAsync(PackingList packingList);
        Task<PackingList> GetPackingListByIdAsync(int id);
        Task<IEnumerable<PackingList>> GetAllPackingListsAsync();
        Task UpdatePackingListAsync(PackingList packingList);
        Task DeletePackingListAsync(int id);
    }
}
