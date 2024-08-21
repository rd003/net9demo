using FluentValidation;
using net9demo.Models;

namespace net9demo.Validators;

public class CategoryValidator:AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(c => c.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(20);
    }
}
