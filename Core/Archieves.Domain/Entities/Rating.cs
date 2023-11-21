using Archieves.Domain.Entities.Common;

namespace Archieves.Domain.Entities
{
    public class Rating : BaseEntity
    {
        public int? Rate { get; set; }
        public int? Count { get; set; }

        public int? BookId { get; set; }
    }
}