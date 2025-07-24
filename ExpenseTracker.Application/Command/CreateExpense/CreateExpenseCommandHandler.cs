using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using ExpenseTracker.Domain.Repositories; // make sure this namespace is correct

namespace ExpenseTracker.Application.Commands.CreateExpense
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, Expense>
    {
        private readonly IExpenseRepository _repository;
        private readonly IPhotoService _photoService;

        public CreateExpenseCommandHandler(
            IExpenseRepository repository,
            IPhotoService photoService)
        {
            _repository = repository;
            _photoService = photoService;
        }

        public async Task<Expense> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            string uploadedImageUrl = null;

            // 🖼 Upload image if provided
            if (request.BillImage != null)
            {
                uploadedImageUrl = await _photoService.UploadImageAsync(request.BillImage);
            }

            var expense = new Expense
            {
                Description = request.Description,
                TransactionDate = request.TransactionDate,
                Value = request.Value,
                AccountId = request.AccountId,
                CategoryId = request.CategoryId,
                ExpenseTypeId = request.ExpenseTypeId,
                BillImgUrl = uploadedImageUrl // ✅ Add image URL
            };

            var result = await _repository.CreateAsync(expense);
            return result;
        }
    }
}
