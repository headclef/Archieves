using Archieves.Kutuphane.Models.User;
using FluentValidation;

namespace Archieves.Kutuphane.ValidationRules
{
    public class LogInValidator : AbstractValidator<UserViewModel>
    {
        public LogInValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E - Posta kısmı boş olmamalıdır.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre kısmı boş olmamalıdır.");
        }
    }
}
