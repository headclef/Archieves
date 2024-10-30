using Archieves_Application.Dtos;
using Archieves_Application.Parameters.Common;
using Archieves_Application.Wrappers;

namespace Archieves_Application.Interfaces.Services.Abstract
{
    public interface IBookService
    {
        #region Methods
        Task<ModelResponse<BookDto>> AddAsync(BookDto bookDto);
        Task<ModelResponse<BookDto>> UpdateAsync(BookDto bookDto);
        Task<ModelResponse<BookDto>> DeleteAsync(BookDto bookDto);
        Task<ModelResponse<BookDto>> DeleteAsync(int id);
        Task<ModelResponse<BookDto>> GetByIdAsync(int id);
        Task<PagedModelResponse<List<BookDto>>> GetAllAsync(ArchievesListRequestParameter parameter);
        #endregion
    }
}