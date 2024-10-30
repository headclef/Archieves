using Archieves_Application.Dtos.Common;

namespace Archieves_Application.Dtos
{
    public class CategoryDto : ArchievesDto
    {
        #region Properties
        public string? Title { get; set; }
        public string? Description { get; set; }
        #endregion
    }
}