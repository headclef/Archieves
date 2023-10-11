using Archieves.Kutuphane.Models.Book;
using Archieves.Kutuphane.Models.Common;
using Archieves.Kutuphane.Models.User;

namespace Archieves.Kutuphane.Models.Comment
{
    public class CommentViewModel : BaseViewModel
    {
        public string Content { get; set; }
        public int Rate { get; set; }

        public int BookId { get; set; }
        public BookViewModel Book { get; set; }

        public int UserId { get; set; }
        public UserViewModel User { get; set; }
    }
}
