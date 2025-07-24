using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using MediatR;

namespace ExpenseTracker.Application.Query.GetAllAccount
{
    public class GetAllAccountQueryHandler : IRequestHandler<GetAllAccountQuery, List<Account>>
    {
        private readonly IAccountRepository _repository;

        public GetAllAccountQueryHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Account>> Handle(GetAllAccountQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _repository.GetAllAsync();
            return accounts;
        }
    }
}
