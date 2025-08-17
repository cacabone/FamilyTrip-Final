using AutoMapper;
using FamilyTrip.Application.Contract;
using FamilyTrip.Application.DTOs;
using FamilyTrip.Application.DTOs.FamilyMember;
using FamilyTrip.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTrip.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FamilyMemberController : ControllerBase
    {
        private readonly IFamilyMemberService _service;
        private readonly IMapper _mapper;

        public FamilyMemberController(IFamilyMemberService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamilyMemberDto>>> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<FamilyMemberDto>>(list));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FamilyMemberDto>> GetById(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity is null) return NotFound();
            return Ok(_mapper.Map<FamilyMemberDto>(entity));
        }

        [HttpPost]
        public async Task<ActionResult<FamilyMemberDto>> Create(FamilyMemberDto dto)
        {
            var entity = _mapper.Map<FamilyMember>(dto);
            var created = await _service.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<FamilyMemberDto>(created));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, FamilyMemberDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var existing = await _service.GetByIdAsync(id);
            if (existing is null) return NotFound();

            _mapper.Map(dto, existing);
            await _service.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
