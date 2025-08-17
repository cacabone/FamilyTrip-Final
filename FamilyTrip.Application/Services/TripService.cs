using FamilyTrip.Application.Contract;
using FamilyTrip.Application.DTOs;
using FamilyTrip.Application.DTOs.Trip;
using FamilyTrip.Domain.Entities;
using FamilyTrip.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace FamilyTrip.Application.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public TripService(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Trip>> GetAllTripsAsync()
        {
            return await _tripRepository.GetAllAsync();
        }

        public async Task<Trip?> GetTripByIdAsync(int id)
        {
            return await _tripRepository.GetByIdAsync(id);
        }

        public async Task<Trip> CreateTripAsync(Trip trip)
        {
            return await _tripRepository.AddAsync(trip);
        }

        public async Task<Trip> UpdateTripAsync(Trip trip)
        {
            return await _tripRepository.UpdateAsync(trip);
        }

        public async Task<bool> DeleteTripAsync(int id)
        {
            return await _tripRepository.DeleteAsync(id);
        }

        public async Task AddTripAsync(CreateTripDto createTripDto)
        {
            var trip = _mapper.Map<Trip>(createTripDto);
            await _tripRepository.AddAsync(trip);           
        }
    }
}
