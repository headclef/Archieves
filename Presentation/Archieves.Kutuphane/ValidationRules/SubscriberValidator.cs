using Archieves.Domain.Entities;
using FluentValidation;

namespace Archieves.Kutuphane.ValidationRules
{
    public class SubscriberValidator : AbstractValidator<Subscriber>
    {
        public SubscriberValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("The email field can not be empty and email must be valid.");
        }
    }
}
