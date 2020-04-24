using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doctrin.Api.Resources;

namespace Doctrin.Api.Controllers.Validators
{
    public class SaveSettingResourceValidator : AbstractValidator<SaveSettingResource>
    {
        public SaveSettingResourceValidator()
        {
            RuleFor(a => a.GlobalId)
                .NotEmpty();

            RuleFor(a => a.Value)
                .NotEmpty();
        }
    }
}
