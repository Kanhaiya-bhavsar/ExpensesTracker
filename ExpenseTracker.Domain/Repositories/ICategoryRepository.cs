using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.DTOs;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Domain.Repositories
{
    public interface ICategoryRepository
    {
      
            Task<Category?> CreateAsync(Category category);
            Task<Category?> DeleteAsync(int id);
            Task<List<Category>> GetAllAsync();
            Task<Category?> GetByIdAsync(int id);
            Task<Category?> UpdateAsync(Category category);

            Task<List<Expense>> GetExpensesbyCategoryIdAsync(int id);

        Task<List<CategoryTotalDto>> GetAllCategoryTotal();






    }
}
