using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.DTOs;
using ExpenseTracker.Domain.Entities;
using MediatR;

namespace ExpenseTracker.Application.Query.GetAllCategoryTotal
{
    public class GetAllCategoryTotalQuery : IRequest<List<CategoryTotalDto>>
    {
    }
}
