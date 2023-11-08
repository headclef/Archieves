using System.ComponentModel.DataAnnotations;

namespace Archieves.Kutuphane.Models.Book
{
    public class BookViewModel
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }

        public int? AuthorId { get; set; }
        public string? AuthorName { get; set; } // Extra property for Author name.
        public string? AuthorSurname { get; set; }    // Extra property for Author surname.

        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
    }
}
