using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;
using MediatR;

namespace ExpenseTracker.Application.Query.GetExpenseById
{
    public class GetExpenseByIdQuery : IRequest<Expense>
    {
        public int Id { get; }

        public GetExpenseByIdQuery(int id)
        {
            Id = id;
        }
    }
}
