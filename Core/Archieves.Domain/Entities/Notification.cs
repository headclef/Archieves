using Archieves.Domain.Entities.Common;

namespace Archieves.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string? Message { get; set; }
        public string? Icon { get; set; }
        public string? Type { get; set; }
    }
}
