using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using MediatR;

namespace ExpenseTracker.Application.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Category>
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetByIdAsync(request.Id);
            if (existing == null) return null;

            existing.Name = request.Name;

            return await _repository.UpdateAsync(existing);
        }
    }
}
