using System.ComponentModel.DataAnnotations;

namespace Archieves.Kutuphane.Models.Comment
{
    public class CommentViewModel
    {
        [Key]
        public int Id { get; set; }

        public string? Content { get; set; }
        public int? Rate { get; set; }

        public int? BookId { get; set; }
        public string? BookName { get; set; }       // Extra property for Book name.

        public int? UserId { get; set; }
        public string? UserName { get; set; }       // Extra property for User name.
        public string? UserSurname { get; set; }    // Extra property for User surname.

        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
    }
}
