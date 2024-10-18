namespace Archieves_Application.Dtos
{
    public class BookCategoryDto
    {
        #region Primary Key
        public int Id { get; set; }
        #endregion
        #region Properties
        public int? BookId { get; set; }
        public int? CategoryId { get; set; }
        #endregion
    }
}