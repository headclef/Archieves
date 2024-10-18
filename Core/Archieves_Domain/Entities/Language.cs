using System.ComponentModel.DataAnnotations;

namespace Archieves_Domain.Entities
{
    public class Language
    {
        #region Primary Key
        [Key]
        public int Id { get; set; }
        #endregion
        #region Properties
        public string? Name { get; set; }
        public string? Code { get; set; }
        #endregion
    }
}