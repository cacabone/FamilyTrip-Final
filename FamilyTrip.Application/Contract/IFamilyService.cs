using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyTrip.Domain.Entities;

namespace FamilyTrip.Application.Contract
{
    public interface IFamilyService
    {
        Task<Family> AddFamilyAsync(Family family);
        Task<Family> GetFamilyByIdAsync(int id);
        Task<IEnumerable<Family>> GetAllFamiliesAsync();
        Task UpdateFamilyAsync(Family family);
        Task DeleteFamilyAsync(int id);
    }
}
