using ExpenseTracker.Domain.Entities;
using MediatR;

namespace ExpenseTracker.Application.Commands.DeleteExpense
{
    public class DeleteExpenseCommand : IRequest<Expense>
    {
        public int Id { get; set; }

        public DeleteExpenseCommand(int id)
        {
            Id = id;
        }
    }
}
