using System.Linq;
using Domain.Requests;
using Domain.Services.Interfaces;
using FluentValidation;

namespace Domain.Validators
{
    public class AddBeerValidator : AbstractValidator<AddBeerRequest>
    {
        public AddBeerValidator(IBeerCatalog catalog)
        {
            RuleFor(x => x.Label)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .Custom((label, context) =>
                {
                    if (catalog.GetAllBeers().Any(y => y.Label.Value.Equals(label)))
                        context.AddFailure($"The label \"{label}\" already exists.");
                });

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