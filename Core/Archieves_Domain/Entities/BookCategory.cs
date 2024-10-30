using Archieves_Domain.Entities.Common;

namespace Archieves_Domain.Entities
{
    public class BookCategory : ArchievesEntity
    {
        #region Properties
        public int? BookId { get; set; }
        public int? CategoryId { get; set; }
        #endregion
    }
}