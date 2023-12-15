using FluentValidation;
using net9demo.Models;

namespace net9demo.Validators;

public class PersonValidator: AbstractValidator<Person>
{
    public PersonValidator()
    {
      RuleFor(person=>person.Name).NotNull().MaximumLength(50);
      RuleFor(person=>person.Email).NotNull().MaximumLength(50).EmailAddress();
      RuleFor(person => person.Age).NotNull();
        RuleFor(person => person.Password).NotEmpty().NotNull().MaximumLength(20).Matches("^(?=.*\\d).*$").WithMessage("Password must contain numeric value");
    }
}
