using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Domain.Models;

namespace TextRPG.Domain.Validators
{
    public class StoryValidator : AbstractValidator<Story>
    {
        public StoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Название сюжета не может быть пустым");
        }
    }
}
