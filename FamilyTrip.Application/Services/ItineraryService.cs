using System.Threading.Tasks;
using AutoMapper;
using FamilyTrip.Application.Contract;
using FamilyTrip.Application.DTOs.Itinerary;
using FamilyTrip.Domain.Entities;
using FamilyTrip.Infrastructure.Repository;

namespace FamilyTrip.Application.Service
{
    public class ItineraryService : IItineraryService
    {
        private readonly IItineraryRepository _itineraryRepository;
        private readonly IMapper _mapper;

        public ItineraryService(IItineraryRepository itineraryRepository, IMapper mapper)
        {
            _itineraryRepository = itineraryRepository;
            _mapper = mapper;
        }

        public async Task<Itinerary> AddItineraryAsync(CreateItineraryDto createItineraryDto)
        {
            var itinerary = _mapper.Map<Itinerary>(createItineraryDto);
            return await _itineraryRepository.AddItineraryAsync(itinerary);
        }

        public async Task<Itinerary> GetByIdAsync(int id)
        {
            return await _itineraryRepository.GetItineraryByIdAsync(id);
        }

        public async Task UpdateItineraryAsync(Itinerary itinerary)
        {
            await _itineraryRepository.UpdateItineraryAsync(itinerary);
        }

        public async Task DeleteItineraryAsync(int id)
        {
            await _itineraryRepository.DeleteItineraryAsync(id);
        }
    }
}
