using FamilyTrip.Application.DTOs.FamilyMember;
using FamilyTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTrip.Application.Contract
{
    public interface IFamilyMemberService
    {
        Task<IEnumerable<FamilyMember>> GetAllAsync();
        Task<FamilyMember> GetByIdAsync(int id);
        Task<FamilyMember> AddAsync(FamilyMember member);
        Task<FamilyMember> UpdateAsync(FamilyMember member);
        Task<bool> DeleteAsync(int id);
        Task AddFamilyMemberAsync(CreateFamilyMemberDto createFamilyMemberDto);
    }
}
