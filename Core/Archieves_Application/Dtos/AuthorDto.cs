using Archieves_Application.Dtos.Common;

namespace Archieves_Application.Dtos
{
    public class AuthorDto : ArchievesDto
    {
        #region Properties
        public int? PersonId { get; set; }
        public string? Description { get; set; }
        #endregion
    }
}