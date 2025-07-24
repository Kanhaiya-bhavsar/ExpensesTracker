using ExpenseTracker.Domain.Entities;
using MediatR;

namespace ExpenseTracker.Application.Commands.UpdateAccount
{
    public class UpdateAccountCommand : IRequest<Account>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
