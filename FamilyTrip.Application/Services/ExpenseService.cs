using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyTrip.Application.Contract;
using FamilyTrip.Domain.Entities;
using FamilyTrip.Infrastructure.Repositories;

namespace FamilyTrip.Application.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            return await _expenseRepository.GetAllAsync();
        }

        public async Task<Expense?> GetExpenseByIdAsync(int id)
        {
            return await _expenseRepository.GetByIdAsync(id);
        }

        public async Task CreateExpenseAsync(Expense expense)
        {
            await _expenseRepository.AddAsync(expense);
        }

        public async Task UpdateExpenseAsync(Expense expense)
        {
            await _expenseRepository.UpdateAsync(expense);
        }

        public async Task DeleteExpenseAsync(int id)
        {
            await _expenseRepository.DeleteAsync(id);
        }
    }
}
