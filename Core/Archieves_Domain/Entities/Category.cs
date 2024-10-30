using Archieves_Domain.Entities.Common;

namespace Archieves_Domain.Entities
{
    public class Category : ArchievesEntity
    {
        #region Properties
        public string? Title { get; set; }
        public string? Description { get; set; }
        #endregion
    }
}