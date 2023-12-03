namespace Archieves.Kutuphane.Models.Book
{
    public class BookPagerModel : IBookPagerModel
    {
        public int Number { get; set; } = 1;
        public int Size { get; set; } = 9;
    }
}
