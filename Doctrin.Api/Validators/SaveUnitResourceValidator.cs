using Doctrin.Api.Resources;
using FluentValidation;

namespace Doctrin.Api.Validators
{
    public class SaveUnitResourceValidator : AbstractValidator<SaveUnitResource>
    {
        public SaveUnitResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
