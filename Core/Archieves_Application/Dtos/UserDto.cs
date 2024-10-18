namespace Archieves_Application.Dtos
{
    public class UserDto
    {
        #region Primary Key
        public int Id { get; set; }
        #endregion
        #region Properties
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int PersonId { get; set; }
        #endregion
    }
}