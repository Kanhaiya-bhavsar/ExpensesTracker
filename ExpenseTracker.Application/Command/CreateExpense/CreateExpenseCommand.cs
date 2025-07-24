using ExpenseTracker.Domain.Entities;
using MediatR;
using System;
using Microsoft.AspNetCore.Http;

namespace ExpenseTracker.Application.Commands.CreateExpense
{
    public class CreateExpenseCommand : IRequest<Expense>
    {
        public string Description { get; set; }
        public DateOnly TransactionDate { get; set; }
        public decimal Value { get; set; }

        public int AccountId { get; set; }
        public int CategoryId { get; set; }
        public int ExpenseTypeId { get; set; }

        public IFormFile? BillImage { get; set; }
    }
}
