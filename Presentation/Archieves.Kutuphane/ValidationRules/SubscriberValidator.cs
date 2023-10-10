using Archieves.Kutuphane.Models.Subscriber;
using FluentValidation;

namespace Archieves.Kutuphane.ValidationRules
{
    public class SubscriberAddModelValidator : AbstractValidator<SubscriberAddModel>
    {
        public SubscriberAddModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("The email field can not be empty and email must be valid.");
        }
    }
}
