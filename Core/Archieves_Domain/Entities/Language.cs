using Archieves_Domain.Entities.Common;

namespace Archieves_Domain.Entities
{
    public class Language : ArchievesEntity
    {
        #region Properties
        public string? Name { get; set; }
        public string? Code { get; set; }
        #endregion
    }
}