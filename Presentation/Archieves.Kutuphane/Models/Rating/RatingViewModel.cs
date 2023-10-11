using Archieves.Kutuphane.Models.Book;
using Archieves.Kutuphane.Models.Common;

namespace Archieves.Kutuphane.Models.Rating
{
    public class RatingViewModel : BaseViewModel
    {
        public int Rate { get; set; }
        public int Count { get; set; }

        public int BookId { get; set; }
        public BookViewModel Book { get; set; }
    }
}
