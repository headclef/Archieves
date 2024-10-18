using System.ComponentModel.DataAnnotations;

namespace Archieves_Domain.Entities
{
    public class Gender
    {
        #region Primary Key
        [Key]
        public int Id { get; set; }
        #endregion
        #region Properties
        public string? Name { get; set; }
        #endregion
    }
}