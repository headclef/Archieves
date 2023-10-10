using Archieves.Kutuphane.Models.Author;

namespace Archieves.Kutuphane.Models.Book
{
    public class BookAddModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public int AuthorId { get; set; }
        public AuthorViewModel Author { get; set; }
    }
}
