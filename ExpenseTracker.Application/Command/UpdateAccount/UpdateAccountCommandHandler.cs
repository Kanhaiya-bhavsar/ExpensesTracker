using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using MediatR;

namespace ExpenseTracker.Application.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Account>
    {
        private readonly IAccountRepository _repository;

        public UpdateAccountCommandHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<Account> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetByIdAsync(request.Id);
            if (existing == null) return null;

            existing.Name = request.Name;
            existing.Balance = request.Balance;

            return await _repository.UpdateAsync(existing);
        }
    }
}
