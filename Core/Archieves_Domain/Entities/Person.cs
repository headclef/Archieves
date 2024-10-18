using System.ComponentModel.DataAnnotations;

namespace Archieves_Domain.Entities
{
    public class Person
    {
        #region Primary Key
        [Key]
        public int Id { get; set; }
        #endregion
        #region Properties
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public int GenderId { get; set; }
        #endregion
    }
}