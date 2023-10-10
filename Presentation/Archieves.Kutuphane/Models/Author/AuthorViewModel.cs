using Archieves.Kutuphane.Models.Book;
using Archieves.Kutuphane.Models.Common;

namespace Archieves.Kutuphane.Models.Author
{
    public class AuthorViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Description { get; set; }

        public ICollection<BookViewModel> Books { get; set; }
    }
}
