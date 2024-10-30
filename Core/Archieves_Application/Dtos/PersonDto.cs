using Archieves_Application.Dtos.Common;

namespace Archieves_Application.Dtos
{
    public class PersonDto : ArchievesDto
    {
        #region Properties
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public int GenderId { get; set; }
        #endregion
    }
}