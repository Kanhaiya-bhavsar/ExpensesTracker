using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using MediatR;

namespace ExpenseTracker.Application.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Account>
    {
        private readonly IAccountRepository _repository;

        public DeleteAccountCommandHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<Account> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteAsync(request.Id);
            return result;
        }
    }
}
