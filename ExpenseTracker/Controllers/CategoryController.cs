using System.Threading.Tasks;
using ExpenseTracker.Application.Command.CreateAccount;
using ExpenseTracker.Application.Commands.CreateCategory;
using ExpenseTracker.Application.Commands.DeleteCategory;
using ExpenseTracker.Application.Commands.DeleteExpense;
using ExpenseTracker.Application.Commands.UpdateAccount;
using ExpenseTracker.Application.Commands.UpdateCategory;
using ExpenseTracker.Application.Query.GetAccountById;
using ExpenseTracker.Application.Query.GetAllAccount;
using ExpenseTracker.Application.Query.GetAllCategory;
using ExpenseTracker.Application.Query.GetAllCategoryTotal;
using ExpenseTracker.Application.Query.GetCategoryById;
using ExpenseTracker.Application.Query.GetExpensesByCategoryId;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public ICategoryRepository Repository { get; }

        public CategoryController(IMediator mediator, ICategoryRepository repository)
        {
            this.mediator = mediator;
            Repository = repository;
        }

        // GET: api/category
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await mediator.Send(new GetAllCategoryQuery());
            return Ok(items);
        }

        [HttpGet("totals")]
        public async Task<IActionResult> GetAllCategoryTotaltAll()
        {
            var items = await mediator.Send(new GetAllCategoryTotalQuery());
            return Ok(items);
        }

        [HttpGet("expenses/{id}")]
        public async Task<IActionResult> GetAllExpenseByCategoryId(int id)
        {
            var items = await mediator.Send(new GetExpensesByCategoryIdQuery(id));
            return Ok(items);
        }

        // POST: api/category
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand category)
        {
            if (category == null)
                return BadRequest("Category cannot be null");

            var result = await mediator.Send(category);
            return CreatedAtAction(nameof(GetById), new { id = result?.Id }, result);
        }

        // GET: api/category/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await mediator.Send(new GetAccountByIdQuery(id));
            //var item =await Repository.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // DELETE: api/category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var item = await mediator.Send(new DeleteCategoryCommand(id));
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // PUT: api/category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryCommand category)
        {
            if (category == null || category.Id != id)
                return BadRequest("Category ID mismatch");

            var existingCategory = await  mediator.Send(new GetCategoryByIdQuery(category.Id));
            if (existingCategory == null)
                return NotFound();

            var updated = await mediator.Send(category);
            return Ok(updated);
        }
    }
}
