using Archieves_Domain.Entities.Common;

namespace Archieves_Domain.Entities
{
    public class Person : ArchievesEntity
    {
        #region Properties
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public int GenderId { get; set; }
        #endregion
    }
}