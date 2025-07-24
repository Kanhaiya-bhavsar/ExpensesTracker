using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Application.Query.GetAccountById;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using MediatR;

namespace ExpenseTracker.Application.Query.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryByIdQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var account = await _repository.GetByIdAsync(request.Id);
            return account;
        }
    }
}
