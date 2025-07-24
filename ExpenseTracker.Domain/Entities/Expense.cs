using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateOnly TransactionDate { get; set; }
        public decimal Value { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }

        public string? BillImgUrl { get; set; }
        
    }


}
