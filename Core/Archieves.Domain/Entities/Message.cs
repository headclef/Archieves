using Archieves.Domain.Entities.Common;

namespace Archieves.Domain.Entities
{
    public class Message : BaseEntity
    {
        public int? Sender { get; set; }
        public int? Receiver { get; set; }
        public string? Subject { get; set; }
        public string? Details { get; set; }
    }
}
