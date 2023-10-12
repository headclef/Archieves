using Archieves.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Archieves.Domain.Entities
{
    public class Rating : BaseEntity
    {
        [Range(0, 10)]
        public int Rate { get; set; }
        public int Count { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
