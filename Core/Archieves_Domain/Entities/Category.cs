using System.ComponentModel.DataAnnotations;

namespace Archieves_Domain.Entities
{
    public class Category
    {
        #region Primary Key
        [Key]
        public int Id { get; set; }
        #endregion
        #region Properties
        public string? Title { get; set; }
        public string? Description { get; set; }
        #endregion
    }
}