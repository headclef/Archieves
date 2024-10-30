using Archieves_Application.Dtos.Common;

namespace Archieves_Application.Dtos
{
    public class LanguageDto : ArchievesDto
    {
        #region Properties
        public string? Name { get; set; }
        public string? Code { get; set; }
        #endregion
    }
}