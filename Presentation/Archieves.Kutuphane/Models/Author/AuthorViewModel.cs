using System.ComponentModel.DataAnnotations;

namespace Archieves.Kutuphane.Models.Author
{
    public class AuthorViewModel
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Description { get; set; }

        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
    }
}
