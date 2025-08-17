using AutoMapper;
using FamilyTrip.Application.Contract;
using FamilyTrip.Application.DTOs;
using FamilyTrip.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTrip.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _service;
        private readonly IMapper _mapper;

        public ExpenseController(IExpenseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetAll()
        {
            var list = await _service.GetAllExpensesAsync();
            return Ok(_mapper.Map<IEnumerable<ExpenseDto>>(list));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ExpenseDto>> GetById(int id)
        {
            var entity = await _service.GetExpenseByIdAsync(id);
            if (entity is null) return NotFound();
            return Ok(_mapper.Map<ExpenseDto>(entity));
        }

        [HttpPost]
        public async Task<ActionResult<ExpenseDto>> Create(ExpenseDto dto)
        {
            var entity = _mapper.Map<Expense>(dto);
            await _service.CreateExpenseAsync(entity);
            var result = _mapper.Map<ExpenseDto>(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ExpenseDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var existing = await _service.GetExpenseByIdAsync(id);
            if (existing is null) return NotFound();

            _mapper.Map(dto, existing);
            await _service.UpdateExpenseAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.GetExpenseByIdAsync(id);
            if (existing is null) return NotFound();
            await _service.DeleteExpenseAsync(id);
            return NoContent();
        }
    }
}

