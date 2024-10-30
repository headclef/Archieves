using Archieves_Domain.Entities.Common;

namespace Archieves_Domain.Entities
{
    public class User : ArchievesEntity
    {
        #region Properties
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int PersonId { get; set; }
        #endregion
    }
}