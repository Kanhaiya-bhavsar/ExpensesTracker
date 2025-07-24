using System.Threading.Tasks;
using ExpenseTracker.Application.Commands.CreateExpense;
using ExpenseTracker.Application.Commands.DeleteExpense;
using ExpenseTracker.Application.Commands.UpdateExpense;
using ExpenseTracker.Application.Query.GetAccountById;
using ExpenseTracker.Application.Query.GetAllAccount;
using ExpenseTracker.Application.Query.GetAllExpense;
using ExpenseTracker.Application.Query.GetExpenseById;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ExpenseController : ControllerBase
    {
        private readonly IMediator mediator;

        public ExpenseController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/expense
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await mediator.Send(new GetAllExpenseQuery());
            return Ok(items);
        }

        // POST: api/expense
        [HttpPost]
        public async Task<IActionResult> CreateExpense([FromForm] CreateExpenseCommand expense)
        {
            if (expense == null)
                return BadRequest("Expense cannot be null");

            var result = await mediator.Send(expense);
            return CreatedAtAction(nameof(GetById), new { id = result?.Id }, result);
        }

        // GET: api/expense/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await mediator.Send(new GetExpenseByIdQuery(id));
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // DELETE: api/expense/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var item = await mediator.Send(new DeleteExpenseCommand(id));
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // PUT: api/expense/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense(int id, [FromForm] UpdateExpenseCommand expense)
        {
            if (expense == null || expense.Id != id)
                return BadRequest("Expense ID mismatch");

            var existingExpense = await mediator.Send(new GetExpenseByIdQuery(expense.Id));
            if (existingExpense == null)
                return NotFound();

            var updated = await mediator.Send(expense);
            return Ok(updated);
        }

    }
}
