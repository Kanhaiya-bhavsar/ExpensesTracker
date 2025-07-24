using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;
using MediatR;

namespace ExpenseTracker.Application.Command.CreateAccount
{
    public class CreateAccountCommand : IRequest<Account>
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }

}
