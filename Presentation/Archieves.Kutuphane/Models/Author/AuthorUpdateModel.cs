namespace Archieves.Kutuphane.Models.Author
{
    public class AuthorUpdateModel
    {
        public int Id { get; set; }
        public string? Name { get; set; } = null;
        public string? Surname { get; set; } = null;
        public string? Description { get; set; } = null;
    }
}
