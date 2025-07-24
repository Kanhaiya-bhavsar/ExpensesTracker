using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Application.Command.CreateAccount;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using MediatR;

namespace ExpenseTracker.Application.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Account>
    {
        private readonly IAccountRepository _repository;

        public CreateAccountCommandHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<Account> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account
            {
                Name = request.Name,
                Balance = request.Balance
            };

            var result = await _repository.CreateAsync(account);
            return result;
        }
    }
}
