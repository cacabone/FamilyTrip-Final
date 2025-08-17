using AutoMapper;
using FamilyTrip.Application.Contract;
using FamilyTrip.Application.DTOs.FamilyMember;
using FamilyTrip.Domain.Entities;
using FamilyTrip.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTrip.Application.Service
{
    public class FamilyMemberService : IFamilyMemberService
    {
        private readonly IFamilyRepository _repository;
        private readonly IMapper _mapper;

        public FamilyMemberService(IFamilyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<IEnumerable<FamilyMember>> GetAllAsync() => _repository.GetAllAsync();

        public Task<FamilyMember> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<FamilyMember> AddAsync(FamilyMember member) => _repository.AddAsync(member);

        public Task<FamilyMember> UpdateAsync(FamilyMember member) => _repository.UpdateAsync(member);

        public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);

        public async Task AddFamilyMemberAsync(CreateFamilyMemberDto createFamilyMemberDto)
        {
            var entity = _mapper.Map<FamilyMember>(createFamilyMemberDto);
            await _repository.AddAsync(entity);
        }
    }
}
