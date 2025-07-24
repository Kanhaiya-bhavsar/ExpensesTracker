using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Application.Query.GetAllAccount;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using MediatR;

namespace ExpenseTracker.Application.Query.GetAllExpense
{
    public class GetAllExpenseQueryHandler : IRequestHandler<GetAllExpenseQuery, List<Expense>>
    {
        private readonly IExpenseRepository _repository;

        public GetAllExpenseQueryHandler(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Expense>> Handle(GetAllExpenseQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _repository.GetAllAsync();
            return accounts;
        }
    }
}
