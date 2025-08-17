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
    public class ItineraryRepository : IItineraryRepository
    {
        private readonly FamilyTripDbContext _context;

        public ItineraryRepository(FamilyTripDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItineraryItem>> GetAllAsync()
        {
            return await _context.ItineraryItems.ToListAsync();
        }

        public async Task<ItineraryItem> GetByIdAsync(int id)
        {
            return await _context.ItineraryItems.FindAsync(id);
        }

        public async Task<ItineraryItem> AddAsync(ItineraryItem item)
        {
            _context.ItineraryItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<ItineraryItem> UpdateAsync(ItineraryItem item)
        {
            _context.ItineraryItems.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ItineraryItems.FindAsync(id);
            if (entity == null)
                return false;

            _context.ItineraryItems.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Itinerary> AddItineraryAsync(Itinerary itinerary)
        {
            _context.Set<Itinerary>().Add(itinerary);
            await _context.SaveChangesAsync();
            return itinerary;
        }

        public async Task<Itinerary> GetItineraryByIdAsync(int id)
        {
            return await _context.Set<Itinerary>()
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateItineraryAsync(Itinerary itinerary)
        {
            _context.Set<Itinerary>().Update(itinerary);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItineraryAsync(int id)
        {
            var entity = await _context.Set<Itinerary>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<Itinerary>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
