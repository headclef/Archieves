using Archieves.Domain.Entities.Common;

namespace Archieves.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
