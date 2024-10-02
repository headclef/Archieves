using System.ComponentModel.DataAnnotations;

namespace Archieves.Kutuphane.Models.Message
{
    public class MessageViewModel
    {
        [Key]
        public int Id { get; set; }
        public int? Sender { get; set; }
        public string? SenderName { get; set; }
        public string? SenderSurname { get; set; }
        public int? Receiver { get; set; }
        public string? ReceiverName { get; set; }
        public string? ReceiverSurname { get; set; }
        public string? Subject { get; set; }
        public string? Details { get; set; }
        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
    }
}
