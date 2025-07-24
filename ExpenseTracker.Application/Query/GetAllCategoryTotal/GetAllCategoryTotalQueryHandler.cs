using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Application.Query.GetAllCategory;
using ExpenseTracker.Domain.DTOs;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using MediatR;

namespace ExpenseTracker.Application.Query.GetAllCategoryTotal
{
    internal class GetAllCategoryTotalQueryHandler : IRequestHandler<GetAllCategoryTotalQuery, List<CategoryTotalDto>>
    {
        private readonly ICategoryRepository _repository;

        public GetAllCategoryTotalQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoryTotalDto>> Handle(GetAllCategoryTotalQuery request, CancellationToken cancellationToken)
        {
            var categoryTotalDtos = await _repository.GetAllCategoryTotal();
            return categoryTotalDtos;
        }
    }
}
