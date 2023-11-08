using Archieves.Kutuphane.Models.Comment;
using FluentValidation;

namespace Archieves.Kutuphane.ValidationRules
{
    public class CommentValidator : AbstractValidator<CommentViewModel>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Yorum içeriği boş olamaz.");

            RuleFor(x => x.BookId)
                .NotEmpty().WithMessage("Yorum yapılacak kitap seçilmelidir.");
        }
    }
}