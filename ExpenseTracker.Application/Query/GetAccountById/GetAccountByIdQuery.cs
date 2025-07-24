using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;
using MediatR;

namespace ExpenseTracker.Application.Query.GetAccountById
{
    public class GetAccountByIdQuery : IRequest<Account>
    {
        public int Id { get; }

        public GetAccountByIdQuery(int id)
        {
            Id = id;
        }
    }
}

