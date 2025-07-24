using System.Threading.Tasks;
using ExpenseTracker.Application.Command.CreateAccount;
using ExpenseTracker.Application.Commands.DeleteAccount;
using ExpenseTracker.Application.Commands.DeleteExpense;
using ExpenseTracker.Application.Commands.UpdateAccount;
using ExpenseTracker.Application.Query.GetAccountById;
using ExpenseTracker.Application.Query.GetAllAccount;
using ExpenseTracker.Application.Query.GetExpenseByAccountId;
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
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator) {
            this.mediator = mediator;
        }

        // GET: api/account
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await mediator.Send(new GetAllAccountQuery());
            return Ok(items);
        }

        // POST: api/account
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand account)
        {
            if (account == null)
                return BadRequest("Account cannot be null");

            var result = await mediator.Send(account);
            return CreatedAtAction(nameof(GetById), new { id = result?.Id }, result);
        }

        // GET: api/account/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await mediator.Send(new GetAccountByIdQuery(id));
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // DELETE: api/account/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var item = await mediator.Send(new DeleteAccountCommand(id));

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet("expenses/{id}")]
        public async Task<IActionResult> GetAllExpenseByAccountId(int id)
        {
            var items = await mediator.Send(new GetExpensesByAccountIdQuery(id));
            return Ok(items);
        }

        // PUT: api/account/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, [FromBody] UpdateAccountCommand account)
        {
            if (account == null || account.Id != id)
                return BadRequest("Account ID mismatch");

            var existingAccount = await mediator.Send(new GetAccountByIdQuery(account.Id));
            if (existingAccount == null)
                return NotFound();

            var updated = await  mediator.Send(account);
            return Ok(updated);
        }
    }
}
