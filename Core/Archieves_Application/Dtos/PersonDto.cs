namespace Archieves_Application.Dtos
{
    public class PersonDto
    {
        #region Primary Key
        public int Id { get; set; }
        #endregion
        #region Properties
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public int GenderId { get; set; }
        #endregion
    }
}