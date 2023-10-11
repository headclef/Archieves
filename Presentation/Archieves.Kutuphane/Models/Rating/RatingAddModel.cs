using Archieves.Kutuphane.Models.Common;

namespace Archieves.Kutuphane.Models.Rating
{
    public class RatingAddModel : BaseViewModel
    {
        public int Rate { get; set; }
        public int Count { get; set; }
        public int BookId { get; set; }
    }
}
