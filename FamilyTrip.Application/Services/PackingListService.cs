using AutoMapper;
using FamilyTrip.Application.Contract;
using FamilyTrip.Application.DTOs.PackingList;
using FamilyTrip.Domain.Entities;
using FamilyTrip.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FamilyTrip.Application.Service
{
    public class PackingListService : IPackingListService
    {
        private readonly IPackingListRepository _repository;
        private readonly IMapper _mapper;

        public PackingListService(IPackingListRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<IEnumerable<PackingItem>> GetAllAsync() => _repository.GetAllAsync();

        public Task<PackingItem> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<PackingItem> AddAsync(PackingItem item) => _repository.AddAsync(item);

        public Task<PackingItem> UpdateAsync(PackingItem item) => _repository.UpdateAsync(item);

        public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);

        public async Task AddPackingItemAsync(CreatePackingItemDto dto)
        {
            var entity = _mapper.Map<PackingItem>(dto);
            await _repository.AddAsync(entity);
        }

        public async Task<PackingListDto> CreatePackingListAsync(CreatePackingListDto dto)
        {
            var entity = _mapper.Map<PackingList>(dto);
            var created = await _repository.AddPackingListAsync(entity);
            return _mapper.Map<PackingListDto>(created);
        }

        public async Task<PackingListDto> GetPackingListByIdAsync(int id)
        {
            var entity = await _repository.GetPackingListByIdAsync(id);
            return _mapper.Map<PackingListDto>(entity);
        }

        public async Task<IEnumerable<PackingListDto>> GetAllPackingListsAsync()
        {
            var entities = await _repository.GetAllPackingListsAsync();
            return _mapper.Map<IEnumerable<PackingListDto>>(entities);
        }

        public async Task UpdatePackingListAsync(PackingList packingList)
        {
            await _repository.UpdatePackingListAsync(packingList);
        }

        public async Task DeletePackingListAsync(int id)
        {
            await _repository.DeletePackingListAsync(id);
        }
    }
}
