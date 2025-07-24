using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<Account?> CreateAsync(Account account);
        Task<Account?> DeleteAsync(int id);
        Task<Account?> GetByIdAsync(int id);
        Task<List<Account>> GetAllAsync();
        Task<Account?> UpdateAsync(Account account);
        Task<List<Expense>> GetExpensesbyAccountIdAsync(int id);
    }


}
