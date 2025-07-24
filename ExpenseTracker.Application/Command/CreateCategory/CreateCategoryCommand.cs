using ExpenseTracker.Domain.Entities;
using MediatR;

namespace ExpenseTracker.Application.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Category>
    {
        public string Name { get; set; }
    }
}
