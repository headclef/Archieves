using Archieves.Domain.Entities.Common;

namespace Archieves.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Description { get; set; }
    }
}