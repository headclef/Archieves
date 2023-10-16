using Archieves.Kutuphane.Models.Common;

namespace Archieves.Kutuphane.Models.Comment
{
    public class CommentUpdateModel : BaseViewModel
    {
        public string Content { get; set; }
        public int Rate { get; set; }

        public int BookId { get; set; }
        public int UserId { get; set; }
    }
}
