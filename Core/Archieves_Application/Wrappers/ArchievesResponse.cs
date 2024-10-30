namespace Archieves_Application.Wrappers
{
    public class ArchievesResponse<T> where T : class
    {
        #region Properties
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public Error Error { get; set; }
        #endregion
    }
}