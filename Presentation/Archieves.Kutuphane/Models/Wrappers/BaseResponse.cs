namespace Archieves.Kutuphane.Models.Wrappers
{
    public class BaseResponse<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public Error Error { get; set; }
    }
}
