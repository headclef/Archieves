namespace Archieves_Application.Dtos
{
    public class AuthorDto
    {
        #region Primary Key
        public int Id { get; set; }
        #endregion
        #region Properties
        public int? PersonId { get; set; }
        public string? Description { get; set; }
        #endregion
    }
}