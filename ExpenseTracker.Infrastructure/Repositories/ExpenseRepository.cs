using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using Microsoft.Identity.Client;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ExpenseTrackerDbContext _context;

        public ExpenseRepository(ExpenseTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<Expense?> CreateAsync(Expense expense)
        {
            await _context.Expense.AddAsync(expense);
            var account =await _context.Account.FirstOrDefaultAsync(x=> x.Id ==expense.AccountId );
            account.Balance = account.Balance - expense.Value;

            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task<Expense?> DeleteAsync(int id)
        {
            var expense = await _context.Expense.FindAsync(id);
            if (expense == null)
                return null;

            _context.Expense.Remove(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task<List<Expense>> GetAllAsync()
        {
            return await _context.Expense
                .Include(e => e.Category)
                .Include(e => e.Account)
                .Include(e => e.ExpenseType) 
                .ToListAsync();
        }

        public async Task<Expense?> GetByIdAsync(int id)
        {
            return await _context.Expense
                .Include(e => e.Category)
                .Include(e => e.Account)
                .Include(e => e.ExpenseType) 
                .FirstOrDefaultAsync(e => e.Id == id);
        }


        public async Task<Expense?> UpdateAsync(Expense expense)
        {
            _context.Expense.Update(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

    }
}
