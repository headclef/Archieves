using System.ComponentModel.DataAnnotations;

namespace Archieves.Kutuphane.Models.Subscriber
{
    public class SubscriberViewModel
    {
        [Key]
        public int Id { get; set; }

        public string? Email { get; set; }

        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
    }
}
