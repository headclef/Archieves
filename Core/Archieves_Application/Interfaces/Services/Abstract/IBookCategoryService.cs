using Archieves_Application.Dtos;
using Archieves_Application.Parameters.Common;
using Archieves_Application.Wrappers;

namespace Archieves_Application.Interfaces.Services.Abstract
{
    public interface IBookCategoryService
    {
        #region Methods
        Task<ModelResponse<BookCategoryDto>> AddAsync(BookCategoryDto bookCategoryDto);
        Task<ModelResponse<BookCategoryDto>> UpdateAsync(BookCategoryDto bookCategoryDto);
        Task<ModelResponse<BookCategoryDto>> DeleteAsync(BookCategoryDto bookCategoryDto);
        Task<ModelResponse<BookCategoryDto>> DeleteAsync(int id);
        Task<ModelResponse<BookCategoryDto>> GetByIdAsync(int id);
        Task<PagedModelResponse<List<BookCategoryDto>>> GetAllAsync(ArchievesListRequestParameter parameter);
        #endregion
    }
}