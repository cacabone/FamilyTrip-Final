using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTrip.Domain.Entities;
using FamilyTrip.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FamilyTrip.Infrastructure.Repository
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly FamilyTripDbContext _context;

        public FamilyRepository(FamilyTripDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FamilyMember>> GetAllAsync() =>
            await _context.FamilyMembers.ToListAsync();

        public async Task<FamilyMember> GetByIdAsync(int id) =>
            await _context.FamilyMembers.FindAsync(id);

        public async Task<FamilyMember> AddAsync(FamilyMember member)
        {
            _context.FamilyMembers.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<FamilyMember> UpdateAsync(FamilyMember member)
        {
            _context.FamilyMembers.Update(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.FamilyMembers.FindAsync(id);
            if (entity == null) return false;

            _context.FamilyMembers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        // Family CRUD
        public async Task<Family> AddFamilyAsync(Family family)
        {
            _context.Family.Add(family);
            await _context.SaveChangesAsync();
            return family;
        }

        public async Task<Family> GetFamilyByIdAsync(int id)
        {
            return await _context.Family.FindAsync(id);
        }

        public async Task<IEnumerable<Family>> GetAllFamiliesAsync()
        {
            return await _context.Family.ToListAsync();
        }

        public async Task UpdateFamilyAsync(Family family)
        {
            _context.Family.Update(family);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFamilyAsync(int id)
        {
            var entity = await _context.Family.FindAsync(id);
            if (entity != null)
            {
                _context.Family.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
