using Archieves.Domain.Entities.Common;

namespace Archieves.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }

        public int? AuthorId { get; set; }
    }
}