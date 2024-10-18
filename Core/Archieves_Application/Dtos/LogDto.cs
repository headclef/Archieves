namespace Archieves_Application.Dtos
{
    public class LogDto
    {
        #region Primary Key
        public int Id { get; set; }
        #endregion
        #region Properties
        public string? Type { get; set; }
        public string? Message { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
        #endregion
    }
}