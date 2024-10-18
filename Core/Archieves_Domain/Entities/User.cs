using System.ComponentModel.DataAnnotations;

namespace Archieves_Domain.Entities
{
    public class User
    {
        #region Primary Key
        [Key]
        public int Id { get; set; }
        #endregion
        #region Properties
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int PersonId { get; set; }
        #endregion
    }
}