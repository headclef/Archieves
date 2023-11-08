using Archieves.Domain.Entities.Common;

namespace Archieves.Domain.Entities
{
    public class Rating : BaseEntity
    {
        // TODO: Set range to 0 - 10 in view and controller (see ViewController.cs)
        public int? Rate { get; set; }
        public int? Count { get; set; }

        // TODO: Add BookName property to model.
        public int? BookId { get; set; }
    }
}