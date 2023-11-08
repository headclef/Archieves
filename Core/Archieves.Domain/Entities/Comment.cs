using Archieves.Domain.Entities.Common;

namespace Archieves.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string? Content { get; set; }
        public int? Rate { get; set; }

        // TODO: Add BookName property to model.
        public int? BookId { get; set; }

        // TODO: Add UserName property to model.
        public int? UserId { get; set; }
    }
}