using System.ComponentModel.DataAnnotations;

namespace Archieves_Domain.Entities
{
    public class Publisher
    {
        #region Primary Key
        [Key]
        public int Id { get; set; }
        #endregion
        #region Properties
        public string? Title { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        #endregion
    }
}