using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;
using MediatR;

namespace ExpenseTracker.Application.Query.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public int Id { get; }

        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
