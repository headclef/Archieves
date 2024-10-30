using Archieves_Application.Dtos.Common;

namespace Archieves_Application.Dtos
{
    public class UserDto : ArchievesDto
    {
        #region Properties
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int PersonId { get; set; }
        #endregion
    }
}