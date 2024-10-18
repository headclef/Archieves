using System.ComponentModel.DataAnnotations;

namespace Archieves_Domain.Entities
{
    public class Log
    {
        #region Primary Key
        [Key]
        public int Id { get; set; }
        #endregion
        #region Properties
        public string? Type { get; set; }
        public string? Message { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
        #endregion
    }
}