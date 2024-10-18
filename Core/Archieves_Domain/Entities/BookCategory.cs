using System.ComponentModel.DataAnnotations;

namespace Archieves_Domain.Entities
{
    public class BookCategory
    {
        #region Primary Key
        [Key]
        public int Id { get; set; }
        #endregion
        #region Properties
        public int? BookId { get; set; }
        public int? CategoryId { get; set; }
        #endregion
    }
}