using ExpenseTracker.Domain.Entities;
using MediatR;

namespace ExpenseTracker.Application.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<Category>
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
