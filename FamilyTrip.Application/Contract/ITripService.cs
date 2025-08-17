using FamilyTrip.Application.DTOs;
using FamilyTrip.Domain.Entities;
using FamilyTrip.Application.DTOs.Trip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTrip.Application.Contract
{
    public interface ITripService
    {
        Task<IEnumerable<Trip>> GetAllTripsAsync();
        Task<Trip?> GetTripByIdAsync(int id);
        Task<Trip> CreateTripAsync(Trip trip);
        Task<Trip> UpdateTripAsync(Trip trip);
        Task<bool> DeleteTripAsync(int id);
        Task AddTripAsync(CreateTripDto createTripDto);
    }
}
