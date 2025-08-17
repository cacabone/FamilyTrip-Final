using AutoMapper;
using FamilyTrip.Application.Contract;
using FamilyTrip.Application.DTOs;
using FamilyTrip.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FamilyTrip.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyService _service;
        private readonly IMapper _mapper;

        public FamilyController(IFamilyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamilyDto>>> GetAll()
        {
            var families = await _service.GetAllFamiliesAsync();
            return Ok(_mapper.Map<IEnumerable<FamilyDto>>(families));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FamilyDto>> GetById(int id)
        {
            var family = await _service.GetFamilyByIdAsync(id);
            if (family == null) return NotFound();
            return Ok(_mapper.Map<FamilyDto>(family));
        }

        [HttpPost]
        public async Task<ActionResult<FamilyDto>> Create(CreateFamilyDto dto)
        {
            var entity = _mapper.Map<Family>(dto);
            var created = await _service.AddFamilyAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<FamilyDto>(created));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CreateFamilyDto dto)
        {
            var existing = await _service.GetFamilyByIdAsync(id);
            if (existing == null) return NotFound();
            var entity = _mapper.Map<Family>(dto);
            entity.Id = id;
            await _service.UpdateFamilyAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.GetFamilyByIdAsync(id);
            if (existing == null) return NotFound();
            await _service.DeleteFamilyAsync(id);
            return NoContent();
        }
    }
}