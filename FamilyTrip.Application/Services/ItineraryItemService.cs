using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FamilyTrip.Application.DTOs.ItineraryItem;
using FamilyTrip.Application.Contract;
using FamilyTrip.Domain.Entities;
using FamilyTrip.Infrastructure.Repository;

namespace FamilyTrip.Application.Service
{
    public class ItineraryItemService : IItineraryItemService
    {
        private readonly IItineraryRepository _itineraryRepository;
        private readonly IMapper _mapper;

        public ItineraryItemService(IItineraryRepository itineraryRepository, IMapper mapper)
        {
            _itineraryRepository = itineraryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItineraryItem>> GetAllAsync()
        {
            return await _itineraryRepository.GetAllAsync();
        }

        public async Task<ItineraryItem> GetByIdAsync(int id)
        {
            return await _itineraryRepository.GetByIdAsync(id);
        }

        public async Task<ItineraryItem> CreateAsync(ItineraryItem item)
        {
            return await _itineraryRepository.AddAsync(item);
        }

        public async Task<ItineraryItem> UpdateAsync(ItineraryItem item)
        {
            return await _itineraryRepository.UpdateAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _itineraryRepository.DeleteAsync(id);
        }
        public async Task AddItineraryItemAsync(CreateItineraryItemDto createItineraryItemDto)
        {
            var entity = _mapper.Map<ItineraryItem>(createItineraryItemDto);
            await _itineraryRepository.AddAsync(entity);
        }
    }
}
