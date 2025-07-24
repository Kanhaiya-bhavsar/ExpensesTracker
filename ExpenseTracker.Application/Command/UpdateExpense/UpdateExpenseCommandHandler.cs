using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using MediatR;
using ExpenseTracker.Domain.Repositories;  // ⬅️ Make sure IPhotoService is in this namespace

namespace ExpenseTracker.Application.Commands.UpdateExpense
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, Expense>
    {
        private readonly IExpenseRepository _repository;
        private readonly IPhotoService _photoService;

        public UpdateExpenseCommandHandler(
            IExpenseRepository repository,
            IPhotoService photoService)
        {
            _repository = repository;
            _photoService = photoService;
        }

        public async Task<Expense> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repository.GetByIdAsync(request.Id);
            if (existing == null) return null;

            // ✅ Update properties
            existing.Description = request.Description;
            existing.TransactionDate = request.TransactionDate;
            existing.Value = request.Value;
            existing.AccountId = request.AccountId;
            existing.CategoryId = request.CategoryId;
            existing.ExpenseTypeId = request.ExpenseTypeId;

            // ✅ Upload and update BillImgUrl if new image provided
            if (request.BillImage != null)
            {
                var uploadedImageUrl = await _photoService.UploadImageAsync(request.BillImage);
                existing.BillImgUrl = uploadedImageUrl;
            }

            return await _repository.UpdateAsync(existing);
        }
    }
}
