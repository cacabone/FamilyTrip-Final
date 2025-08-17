using AutoMapper;
using FamilyTrip.Application.Contract;
using FamilyTrip.Domain.Entities;
using FamilyTrip.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FamilyTrip.Application.Service
{
    public class FamilyService : IFamilyService
    {
        private readonly IFamilyRepository _repository;
        private readonly IMapper _mapper;

        public FamilyService(IFamilyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Family> AddFamilyAsync(Family family)
        {
            return await _repository.AddFamilyAsync(family);
        }

        public async Task<Family> GetFamilyByIdAsync(int id)
        {
            return await _repository.GetFamilyByIdAsync(id);
        }

        public async Task<IEnumerable<Family>> GetAllFamiliesAsync()
        {
            return await _repository.GetAllFamiliesAsync();
        }

        public async Task UpdateFamilyAsync(Family family)
        {
            await _repository.UpdateFamilyAsync(family);
        }

        public async Task DeleteFamilyAsync(int id)
        {
            await _repository.DeleteFamilyAsync(id);
        }
    }
}
