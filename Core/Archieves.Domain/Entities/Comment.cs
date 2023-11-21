using Archieves.Domain.Entities.Common;

namespace Archieves.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string? Content { get; set; }
        public int? Rate { get; set; }

        public int? BookId { get; set; }

        public int? UserId { get; set; }
    }
}