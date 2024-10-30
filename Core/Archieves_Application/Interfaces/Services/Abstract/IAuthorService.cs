using Archieves_Application.Dtos;
using Archieves_Application.Parameters.Common;
using Archieves_Application.Wrappers;

namespace Archieves_Application.Interfaces.Services.Abstract
{
    public interface IAuthorService
    {
        #region Methods
        Task<ModelResponse<AuthorDto>> AddAsync(AuthorDto authorDto);
        Task<ModelResponse<AuthorDto>> UpdateAsync(AuthorDto authorDto);
        Task<ModelResponse<AuthorDto>> DeleteAsync(AuthorDto authorDto);
        Task<ModelResponse<AuthorDto>> DeleteAsync(int id);
        Task<ModelResponse<AuthorDto>> GetByIdAsync(int id);
        Task<PagedModelResponse<List<AuthorDto>>> GetAllAsync(ArchievesListRequestParameter parameter);
        #endregion
    }
}