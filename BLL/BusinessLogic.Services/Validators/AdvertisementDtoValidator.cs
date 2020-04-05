using BusinessLogic.Services.Contracts.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Validators
{
    /// <summary>
    /// Валидатор AdvertisementDto
    /// </summary>
    public class AdvertisementDtoValidator : AbstractValidator<AdvertisementDto>
    {
        public AdvertisementDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("AdvertisementDto Title is required");
        }
    }
}
