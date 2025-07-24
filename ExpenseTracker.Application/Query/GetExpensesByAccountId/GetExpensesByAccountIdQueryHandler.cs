using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Application.Query.GetAllCategory;
using ExpenseTracker.Application.Query.GetCategoryById;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using MediatR;

namespace ExpenseTracker.Application.Query.GetExpenseByAccountId
{
    public class GetExpensesByAccountIdQueryHandler : IRequestHandler<GetExpensesByAccountIdQuery, List<Expense>>
    {
        private readonly IAccountRepository _repository;

        public GetExpensesByAccountIdQueryHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Expense>> Handle(GetExpensesByAccountIdQuery request, CancellationToken cancellationToken)
        {
            var expenses = await _repository.GetExpensesbyAccountIdAsync(request.Id);
            return expenses;
        }
    }
}
