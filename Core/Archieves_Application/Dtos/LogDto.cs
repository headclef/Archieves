using Archieves_Application.Dtos.Common;

namespace Archieves_Application.Dtos
{
    public class LogDto : ArchievesDto
    {
        #region Properties
        public string? Type { get; set; }
        public string? Message { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
        #endregion
    }
}