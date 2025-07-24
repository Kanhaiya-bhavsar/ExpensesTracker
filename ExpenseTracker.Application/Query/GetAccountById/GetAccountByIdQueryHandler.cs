using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using MediatR;

namespace ExpenseTracker.Application.Query.GetAccountById
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, Account>
    {
        private readonly IAccountRepository _repository;

        public GetAccountByIdQueryHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<Account> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var account = await _repository.GetByIdAsync(request.Id);
            return account;
        }
    }
}
