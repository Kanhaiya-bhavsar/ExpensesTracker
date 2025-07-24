using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Application.Query.GetCategoryById;
using ExpenseTracker.Application.Query.GetExpenseByAccountId;
using ExpenseTracker.Application.Query.GetExpensesByCategoryId;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using MediatR;

namespace ExpenseTracker.Application.Query.GetExpenseByCategoryId
{
    public class GetExpensesCategoryIdQueryHandler : IRequestHandler<GetExpensesByCategoryIdQuery, List<Expense>>
    {
        private readonly ICategoryRepository _repository;

        public GetExpensesCategoryIdQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Expense>> Handle(GetExpensesByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var expenses = await _repository.GetExpensesbyCategoryIdAsync(request.Id);
            return expenses;
        }
    }
}