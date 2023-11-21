using Archieves.Kutuphane.Models.Book;
using FluentValidation;

namespace Archieves.Kutuphane.ValidationRules
{
    public class BookValidator : AbstractValidator<BookViewModel>
    {
        public BookValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.AuthorId)
                .NotEmpty();

            RuleFor(x => x.Date)
                .NotEmpty();
        }
    }
}
