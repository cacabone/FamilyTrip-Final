using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTrip.Domain.Entities;

namespace FamilyTrip.Infrastructure.Repositories
{
    public interface ITripRepository
    {
        Task<IEnumerable<Trip>> GetAllAsync();
        Task<Trip> GetByIdAsync(int id);
        Task<Trip> AddAsync(Trip trip);
        Task<Trip> UpdateAsync(Trip trip);
        Task<bool> DeleteAsync(int id);
    }
}
