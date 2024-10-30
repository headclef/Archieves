using Archieves_Application.Dtos;
using Archieves_Application.Parameters.Common;
using Archieves_Application.Wrappers;

namespace Archieves_Application.Interfaces.Services.Abstract
{
    public interface ICategoryService
    {
        #region Methods
        Task<ModelResponse<CategoryDto>> AddAsync(CategoryDto categoryDto);
        Task<ModelResponse<CategoryDto>> UpdateAsync(CategoryDto categoryDto);
        Task<ModelResponse<CategoryDto>> DeleteAsync(CategoryDto categoryDto);
        Task<ModelResponse<CategoryDto>> DeleteAsync(int id);
        Task<ModelResponse<CategoryDto>> GetByIdAsync(int id);
        Task<PagedModelResponse<List<CategoryDto>>> GetAllAsync(ArchievesListRequestParameter parameter);
        #endregion
    }
}