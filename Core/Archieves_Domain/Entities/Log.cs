using Archieves_Domain.Entities.Common;

namespace Archieves_Domain.Entities
{
    public class Log : ArchievesEntity
    {
        #region Properties
        public string? Type { get; set; }
        public string? Message { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
        #endregion
    }
}