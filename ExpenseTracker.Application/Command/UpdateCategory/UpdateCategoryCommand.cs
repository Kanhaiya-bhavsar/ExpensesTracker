using ExpenseTracker.Domain.Entities;
using MediatR;

namespace ExpenseTracker.Application.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
