using AutoMapper;
using FamilyTrip.Application.Contract;
using FamilyTrip.Application.DTOs;
using FamilyTrip.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTrip.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var list = await _service.GetAllUsersAsync();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(list));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var entity = await _service.GetUserByIdAsync(id);
            if (entity is null) return NotFound();
            return Ok(_mapper.Map<UserDto>(entity));
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Create(UserDto dto)
        {
            var entity = _mapper.Map<User>(dto);
            await _service.CreateUserAsync(entity);
            var result = _mapper.Map<UserDto>(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UserDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var existing = await _service.GetUserByIdAsync(id);
            if (existing is null) return NotFound();

            _mapper.Map(dto, existing);
            await _service.UpdateUserAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.GetUserByIdAsync(id);
            if (existing is null) return NotFound();
            await _service.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
