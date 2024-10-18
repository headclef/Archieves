namespace Archieves_Application.Dtos
{
    public class CategoryDto
    {
        #region Primary Key
        public int Id { get; set; }
        #endregion
        #region Properties
        public string? Title { get; set; }
        public string? Description { get; set; }
        #endregion
    }
}