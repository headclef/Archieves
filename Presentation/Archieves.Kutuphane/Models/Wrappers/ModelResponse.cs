namespace Archieves.Kutuphane.Models.Wrappers
{
    public class ModelResponse<T> : BaseResponse<T> where T : class
    {
        public ModelResponse<T> Success(T data) => new ModelResponse<T> { Value = data, IsSuccess = true };
        public ModelResponse<T> Success() => new ModelResponse<T> { IsSuccess = true };
        public ModelResponse<T> Fail(Error error) => new ModelResponse<T> { Error = error, IsSuccess = false };
        public ModelResponse<T> Fail(string errorMessage) => new ModelResponse<T> { Error = new(errorMessage), IsSuccess = false };
    }
}
