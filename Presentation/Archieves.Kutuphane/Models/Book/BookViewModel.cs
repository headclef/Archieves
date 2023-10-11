using Archieves.Kutuphane.Models.Author;
using Archieves.Kutuphane.Models.Comment;
using Archieves.Kutuphane.Models.Common;
using Archieves.Kutuphane.Models.Rating;

namespace Archieves.Kutuphane.Models.Book
{
    public class BookViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public int AuthorId { get; set; }
        public AuthorViewModel Author { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
        public ICollection<RatingViewModel> Ratings { get; set; }
    }
}
