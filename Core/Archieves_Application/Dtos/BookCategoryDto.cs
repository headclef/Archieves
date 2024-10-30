using Archieves_Application.Dtos.Common;

namespace Archieves_Application.Dtos
{
    public class BookCategoryDto : ArchievesDto
    {
        #region Properties
        public int? BookId { get; set; }
        public int? CategoryId { get; set; }
        #endregion
    }
}