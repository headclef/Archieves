using Archieves.Kutuphane.Models.Book;
using Archieves.Kutuphane.Models.Common;

namespace Archieves.Kutuphane.Models
{
    public class CommentViewModel : BaseViewModel
    {
        public string Content { get; set; }

        public int BookId { get; set; }
        public BookViewModel Book { get; set; }

        public int UserId { get; set; }
        public UserViewModel User { get; set; }
    }
}
