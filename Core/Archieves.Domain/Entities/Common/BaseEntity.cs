using System.ComponentModel.DataAnnotations;

namespace Archieves.Domain.Entities.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
    }
}
