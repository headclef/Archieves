namespace Archieves.Kutuphane.Models.Wrappers
{
    public class PagedModelResponse<T> : BaseResponse<T> where T : class
    {
        public int PageNumber { get; set; }
        public int PageItemCount { get; set; }
        public int TotalItemCount { get; set; }
        public int PageCount { get; set; }
        public PagedModelResponse<T> Success(
            T data,
            int pageNumber,
            int pageItemCount,
            int totalItemCount,
            int pageCount
            ) => new PagedModelResponse<T>
            {
                IsSuccess = true,
                Value = data,
                PageNumber = pageNumber,
                PageItemCount = pageItemCount,
                TotalItemCount = totalItemCount,
                PageCount = pageCount
            };
        public PagedModelResponse<T> Success() => new PagedModelResponse<T> { IsSuccess = true };
        public PagedModelResponse<T> Fail(Error error) => new PagedModelResponse<T> { Error = error, IsSuccess = false };
        public PagedModelResponse<T> Fail(string errorMessage) => new PagedModelResponse<T> { Error = new(errorMessage), IsSuccess = false };
    }
}
