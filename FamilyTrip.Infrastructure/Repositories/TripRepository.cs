using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTrip.Domain.Entities;
using FamilyTrip.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace FamilyTrip.Infrastructure.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly FamilyTripDbContext _context;

        public TripRepository(FamilyTripDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trip>> GetAllAsync()
        {
            return await _context.Trips
                .Include(t => t.Organizer)
                .Include(t => t.Participants)
                .Include(t => t.Itineraries)
                .Include(t => t.Expenses)
                .ToListAsync();
        }

        public async Task<Trip> GetByIdAsync(int id)
        {
            return await _context.Trips
                .Include(t => t.Organizer)
                .Include(t => t.Participants)
                .Include(t => t.Itineraries)
                .Include(t => t.Expenses)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Trip> AddAsync(Trip trip)
        {
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
            return trip;
        }

        public async Task<Trip> UpdateAsync(Trip trip)
        {
            _context.Trips.Update(trip);
            await _context.SaveChangesAsync();
            return trip;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip == null) return false;

            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
