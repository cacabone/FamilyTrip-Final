using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTrip.Domain.Entities;
using FamilyTrip.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FamilyTrip.Infrastructure.Repository
{
    public class PackingListRepository : IPackingListRepository
    {
        private readonly FamilyTripDbContext _context;

        public PackingListRepository(FamilyTripDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PackingItem>> GetAllAsync() =>
            await _context.PackingItems.ToListAsync();

        public async Task<PackingItem> GetByIdAsync(int id) =>
            await _context.PackingItems.FindAsync(id);

        public async Task<PackingItem> AddAsync(PackingItem item)
        {
            _context.PackingItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<PackingItem> UpdateAsync(PackingItem item)
        {
            _context.PackingItems.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.PackingItems.FindAsync(id);
            if (entity == null) return false;

            _context.PackingItems.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PackingList> AddPackingListAsync(PackingList packingList)
        {
            _context.Set<PackingList>().Add(packingList);
            await _context.SaveChangesAsync();
            return packingList;
        }

        public async Task<PackingList> GetPackingListByIdAsync(int id)
        {
            return await _context.Set<PackingList>()
                .Include(pl => pl.Items)
                .FirstOrDefaultAsync(pl => pl.Id == id);
        }

        public async Task<IEnumerable<PackingList>> GetAllPackingListsAsync()
        {
            return await _context.Set<PackingList>()
                .Include(pl => pl.Items)
                .ToListAsync();
        }

        public async Task UpdatePackingListAsync(PackingList packingList)
        {
            _context.Set<PackingList>().Update(packingList);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePackingListAsync(int id)
        {
            var entity = await _context.Set<PackingList>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<PackingList>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
