using ExpenseTracker.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace ExpenseTracker.Application.Commands.UpdateExpense
{
    public class UpdateExpenseCommand : IRequest<Expense>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateOnly TransactionDate { get; set; }
        public decimal Value { get; set; }

        public int AccountId { get; set; }
        public int CategoryId { get; set; }
        public int ExpenseTypeId { get; set; }

        public IFormFile? BillImage { get; set; } // ✅ Add this to support image file update
    }
}
