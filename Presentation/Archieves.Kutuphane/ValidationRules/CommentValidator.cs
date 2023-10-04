using Archieves.Domain.Entities;
using FluentValidation;

namespace Archieves.Kutuphane.ValidationRules
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Yorum içeriği boş olamaz.");
            RuleFor(x => x.BookId).NotEmpty().WithMessage("Yorum yapılacak kitap seçilmelidir.");
        }
    }
}
