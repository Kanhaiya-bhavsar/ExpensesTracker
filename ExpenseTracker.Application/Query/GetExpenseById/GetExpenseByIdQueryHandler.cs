using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Application.Query.GetAccountById;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using MediatR;

namespace ExpenseTracker.Application.Query.GetExpenseById
{
    public class GetExpenseByIdQueryHandler : IRequestHandler<GetExpenseByIdQuery, Expense>
    {
        private readonly IExpenseRepository _repository;

        public GetExpenseByIdQueryHandler(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Expense> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
        {
            var account = await _repository.GetByIdAsync(request.Id);
            return account;
        }
    }
}
