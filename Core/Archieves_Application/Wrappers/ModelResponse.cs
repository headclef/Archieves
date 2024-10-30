namespace Archieves_Application.Wrappers
{
    public class ModelResponse<T> : ArchievesResponse<T> where T : class
    {
        #region Methods
        // This method is used to return a success response with data
        public ModelResponse<T> Success(T data) => new ModelResponse<T> { Value = data, IsSuccess = true };
        // This method is used to return a success response without data
        public ModelResponse<T> Success() => new ModelResponse<T> { IsSuccess = true };
        // This method is used to return a failed response with error
        public ModelResponse<T> Fail(Error error) => new ModelResponse<T> { Error = error, IsSuccess = false };
        // This method is used to return a failed response with error message
        public ModelResponse<T> Fail(string errorMessage) => new ModelResponse<T> { Error = new Error(errorMessage), IsSuccess = false };
        #endregion
    }
}