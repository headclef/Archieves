using Archieves.Domain.Entities.Common;

namespace Archieves.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }

        // TODO: Add AuthorName property to model.
        public int? AuthorId { get; set; }
    }
}