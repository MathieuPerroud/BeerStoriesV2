using Domain.Requests;
using Domain.Services.Interfaces;
using FluentValidation;

namespace Domain.Validators
{
    public class UpdateBeerValidator : AbstractValidator<UpdateBeerRequest>
    {
        public UpdateBeerValidator(IBeerCatalog catalog)
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .Custom((id, context) =>
                {
                    if (catalog.GetOneBeer(id) == null)
                        context.AddFailure("Unknown beer.");
                });

            RuleFor(x => x.Label)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(250);

            RuleFor(x => x.Stock)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(int.MaxValue);
        }
    }
}