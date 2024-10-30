namespace Archieves_Application.Wrappers
{
    public class Error
    {
        #region Properties
        public List<string> Errors { get; set; }
        public object Message { get; set; }
        #endregion
        #region Methods
        // If there is no error for constructor
        public Error() { }
        // If there is an error for constructor
        public Error(string error)
        {
            Errors.Add(error);
        }
        // If there are errors for constructor
        public Error(List<string> errors)
        {
            Errors = errors;
        }
        #endregion
    }
}