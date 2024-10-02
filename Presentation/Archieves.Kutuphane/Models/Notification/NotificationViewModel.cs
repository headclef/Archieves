using System.ComponentModel.DataAnnotations;

namespace Archieves.Kutuphane.Models.Notification
{
    public class NotificationViewModel
    {
        [Key]
        public int Id { get; set; }
        public string? Message { get; set; }
        public string? Icon { get; set; }
        public string? Type { get; set; }
        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
    }
}
