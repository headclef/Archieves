using System.ComponentModel.DataAnnotations;

namespace Archieves_Domain.Entities
{
    public class Book
    {
        #region Primary Key
        [Key]
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