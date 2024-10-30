using Archieves_Domain.Entities.Common;

namespace Archieves_Domain.Entities
{
    public class Publisher : ArchievesEntity
    {
        #region Properties
        public string? Title { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        #endregion
    }
}