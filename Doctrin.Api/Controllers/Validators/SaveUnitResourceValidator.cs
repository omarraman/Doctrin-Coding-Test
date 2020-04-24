using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doctrin.Api.Resources;

namespace Doctrin.Api.Controllers.Validators
{
    public class SaveUnitResourceValidator : AbstractValidator<SaveUnitResource>
    {
        public SaveUnitResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty();
        }
    }
}
