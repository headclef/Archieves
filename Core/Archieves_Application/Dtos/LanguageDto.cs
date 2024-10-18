namespace Archieves_Application.Dtos
{
    public class LanguageDto
    {
        #region Primary Key
        public int Id { get; set; }
        #endregion
        #region Properties
        public string? Name { get; set; }
        public string? Code { get; set; }
        #endregion
    }
}