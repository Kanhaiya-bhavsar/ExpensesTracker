using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using MediatR;

namespace ExpenseTracker.Application.Commands.DeleteExpense
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, Expense>
    {
        private readonly IExpenseRepository _repository;

        public DeleteExpenseCommandHandler(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Expense> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteAsync(request.Id);
            return result;
        }
    }
}
