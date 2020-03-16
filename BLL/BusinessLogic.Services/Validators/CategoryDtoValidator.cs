using BusinessLogic.Services.Contracts.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Validators
{
    public class CategoryDtoValidator : AbstractValidator <CategoryDto>
    {
        /// <summary>
        /// Валидатор категории
        /// </summary>
        public CategoryDtoValidator ()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("CategoryDto поле Name не заполнено");
        }
    }
}
