using Archieves_Application.Dtos.Common;

namespace Archieves_Application.Dtos
{
    public class PublisherDto : ArchievesDto
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