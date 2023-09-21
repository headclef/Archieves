using Archieves.Domain.Entities;
using FluentValidation;

namespace Archieves.Kutuphane.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("The name field can not be empty.");

            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("The surname field can not be empty.");
            
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("The email field can not be empty and email must be valid.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .WithMessage("The Password can not be lesser than 6 characters.");

            RuleFor(x => x.Phone)
                .MaximumLength(11)
                .WithMessage("The phone number can not be longer than 11 characters.");

            RuleFor(x => x.Address)
                .NotEmpty()
                .MinimumLength(10)
                .WithMessage("The address field can not be empty and address can not be lesser than 10 characters.");
        }
    }
}
/*
 * .MustAsync(async (password, cancellation) =>
                 {
                     var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
                     return await Task.FromResult(regex.IsMatch(password));
                 })
*/