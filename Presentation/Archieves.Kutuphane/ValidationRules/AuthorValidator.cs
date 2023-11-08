using Archieves.Kutuphane.Models.Author;
using FluentValidation;

namespace Archieves.Kutuphane.ValidationRules
{
    public class AuthorValidator : AbstractValidator<AuthorViewModel>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Surname)
                .NotEmpty();

            RuleFor(x => x.Date)
                .NotEmpty();
        }
    }
}
