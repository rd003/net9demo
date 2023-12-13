using FluentValidation;
using net9demo.Models;

namespace net9demo.Validators
{
    public class PersonValidator: AbstractValidator<Person>
    {
        public PersonValidator()
        {
          RuleFor(person=>person.Name).NotNull().MaximumLength(50);
          RuleFor(person=>person.Email).NotNull().MaximumLength(50);
            RuleFor(person => person.Age).NotNull();
        }
    }
}
