using System.ComponentModel.DataAnnotations;

namespace Archieves_Domain.Entities.Common
{
    public class ArchievesEntity
    {
        #region Primary Key
        [Key]
        public int Id { get; set; }
        #endregion
    }
}