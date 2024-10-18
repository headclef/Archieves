using System.ComponentModel.DataAnnotations;

namespace Archieves_Domain.Entities
{
    public class Author
    {
        #region Primary Key
        [Key]
        public int Id { get; set; }
        #endregion
        #region Properties
        public int? PersonId { get; set; }
        public string? Description { get; set; }
        #endregion
    }
}