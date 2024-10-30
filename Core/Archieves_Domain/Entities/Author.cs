using Archieves_Domain.Entities.Common;

namespace Archieves_Domain.Entities
{
    public class Author : ArchievesEntity
    {
        #region Properties
        public int? PersonId { get; set; }
        public string? Description { get; set; }
        #endregion
    }
}