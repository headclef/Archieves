using Archieves.Kutuphane.Models.User;
using FluentValidation;

namespace Archieves.Kutuphane.ValidationRules
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim kısmı boş olmamalıdır.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyisim kısmı boş olmamalıdır.");
            
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E - Posta kısmı boş olmamalıdır.")
                .EmailAddress().WithMessage("E - Posta kısmı geçersiz olmamalıdır.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre kısmı boş olmamalıdır.")
                .MinimumLength(6).WithMessage("Şifre kısmı 6 karakterden küçük olmamalıdır.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon Numarası kısmı boş olmamalıdır.")
                .MaximumLength(10).WithMessage("Telefon Numarası 10 karakterden fazla olmamalıdır.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres kısmı boş olmamalıdır.")
                .MinimumLength(10).WithMessage("Adres kımı 10 karakterden küçük olmamalıdır.");
        }
    }
}