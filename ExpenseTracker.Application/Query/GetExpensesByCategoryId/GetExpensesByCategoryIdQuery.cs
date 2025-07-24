using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;
using MediatR;

namespace ExpenseTracker.Application.Query.GetExpensesByCategoryId
{
    public class GetExpensesByCategoryIdQuery : IRequest<List<Expense>>
    {
        public int Id { get; }

        public GetExpensesByCategoryIdQuery(int id)
        {
            Id = id;
        }
    }
}

