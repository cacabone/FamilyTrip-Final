using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTrip.Domain.Entities;

namespace FamilyTrip.Infrastructure.Repository
{
    public interface IFamilyRepository
    {
        Task<IEnumerable<FamilyMember>> GetAllAsync();
        Task<FamilyMember> GetByIdAsync(int id);
        Task<FamilyMember> AddAsync(FamilyMember member);
        Task<FamilyMember> UpdateAsync(FamilyMember member);
        Task<bool> DeleteAsync(int id);
        // Add Family CRUD
        Task<Family> AddFamilyAsync(Family family);
        Task<Family> GetFamilyByIdAsync(int id);
        Task<IEnumerable<Family>> GetAllFamiliesAsync();
        Task UpdateFamilyAsync(Family family);
        Task DeleteFamilyAsync(int id);
    }
}
