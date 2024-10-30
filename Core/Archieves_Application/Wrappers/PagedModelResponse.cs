namespace Archieves_Application.Wrappers
{
    public class PagedModelResponse<T> : ArchievesResponse<T> where T : class
    {
        #region Properties
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        #endregion
        #region Methods
        // This method is used to return a success response with data
        public PagedModelResponse<T> Success(T data, int pageNumber, int pageSize, int totalPages, int totalItems)
            => new PagedModelResponse<T>
            {
                IsSuccess = true,
                Value = data,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalItems = totalItems
            };
        // This method is used to return a success response without data
        public PagedModelResponse<T> Success() => new PagedModelResponse<T> { IsSuccess = true };
        // This method is used to return a failed response with error
        public PagedModelResponse<T> Fail(Error error) => new PagedModelResponse<T> { IsSuccess = false, Error = error };
        // This method is used to return a failed response with error message
        public PagedModelResponse<T> Fail(string errorMessage) => new PagedModelResponse<T> { IsSuccess = false, Error = new Error(errorMessage) };
        #endregion
    }
}