using System.ComponentModel.DataAnnotations;

namespace Archieves.Kutuphane.Models.Rating
{
    public class RatingViewModel
    {
        [Key]
        public int Id { get; set; }

        public int? Rate { get; set; }
        public int? Count { get; set; }

        public int? BookId { get; set; }
        public string? BookName { get; set; }   // Extra property for Book name.

        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
    }
}
