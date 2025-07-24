using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ExpenseTrackerDbContext _context;

        public AccountRepository(ExpenseTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<Account?> CreateAsync(Account account)
        {
            await _context.Account.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account?> DeleteAsync(int id)
        {
            var account = await _context.Account.FindAsync(id);
            if (account == null)
                return null;

            _context.Account.Remove(account);
            await _context.SaveChangesAsync();
            return account;
        }




        public async Task<Account?> GetByIdAsync(int id)
        {
            return await _context.Account.FindAsync(id);
        }

        public async Task<List<Account>> GetAllAsync()
        {
            return await _context.Account.ToListAsync();
        }

        public async Task<Account?> UpdateAsync(Account account)
        {
            var existing = await _context.Account.FindAsync(account.Id);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(account);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<List<Expense>> GetExpensesbyAccountIdAsync(int id)
        {
            return await _context.Expense.Where(c => c.AccountId == id).Include(e => e.Category)
                .Include(e => e.Account).ToListAsync();
        }
    }
}
