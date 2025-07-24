using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;
using MediatR;

namespace ExpenseTracker.Application.Query.GetExpenseByAccountId
{
    public class GetExpensesByAccountIdQuery : IRequest<List<Expense>>
    {
        public int Id { get; }

        public GetExpensesByAccountIdQuery(int id)
        {
            Id = id;
        }
    }
}

