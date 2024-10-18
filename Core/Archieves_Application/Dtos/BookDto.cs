namespace Archieves_Application.Dtos
{
    public class BookDto
    {
        #region Primary Key
        public int Id { get; set; }
        #endregion
        #region Properties
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? LanguageId { get; set; }
        public int? PageCount { get; set; }
        public int? Year { get; set; }
        public string? ISBN { get; set; }
        public int? AuthorId { get; set; }
        public int? PublisherId { get; set; }
        public string? Image { get; set; }
        #endregion
    }
}