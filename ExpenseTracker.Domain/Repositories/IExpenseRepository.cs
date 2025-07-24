using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Domain.Repositories
{
    public interface IExpenseRepository
    {
        Task<Expense?> CreateAsync(Expense expense);
        Task<Expense?> DeleteAsync(int id);
        Task<List<Expense>> GetAllAsync();
        Task<Expense?> GetByIdAsync(int id);
        Task<Expense?> UpdateAsync(Expense expense);
    }

}
