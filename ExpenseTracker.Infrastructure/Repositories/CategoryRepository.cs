using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using ExpenseTracker.Domain.DTOs;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ExpenseTrackerDbContext _context;

        public CategoryRepository(ExpenseTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<Category?> CreateAsync(Category category)
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var item = await _context.Category.FindAsync(id);

            if (item == null)
                return null;

            _context.Category.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Category
                 .ToListAsync();
        }

        public async Task<List<CategoryTotalDto>> GetAllCategoryTotal()
        {
            var result = await _context.Expense
        .GroupBy(e => new { e.CategoryId, e.Category.Name })
        .Select(g => new CategoryTotalDto
        {
            Id = g.Key.CategoryId,
            Name = g.Key.Name,
            Total = (int)g.Sum(e => e.Value)  // assuming 'Value' is the amount
        })
        .ToListAsync();

            return result;
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Category
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Expense>> GetExpensesbyCategoryIdAsync(int id)
        {
            return await _context.Expense.Where(c => c.CategoryId == id).Include(e => e.Category)
                .Include(e => e.Account).ToListAsync();
           
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
            var existing = await _context.Category.FindAsync(category.Id);
            if (existing == null)
                return null;

            _context.Entry(existing).CurrentValues.SetValues(category);
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
