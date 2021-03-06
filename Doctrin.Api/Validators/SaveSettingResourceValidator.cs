﻿using Doctrin.Api.Resources;
using FluentValidation;

namespace Doctrin.Api.Validators
{
    public class SaveSettingResourceValidator : AbstractValidator<SaveSettingResource>
    {
        public SaveSettingResourceValidator()
        {
            RuleFor(a => a.GlobalId)
                .NotEmpty()
                .MaximumLength(100)
                ;

            RuleFor(a => a.Value)
                .NotEmpty()
                .MaximumLength(200)
                ;
        }
    }
}
