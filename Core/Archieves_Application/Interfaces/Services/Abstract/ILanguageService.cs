using Archieves_Application.Dtos;
using Archieves_Application.Parameters.Common;
using Archieves_Application.Wrappers;

namespace Archieves_Application.Interfaces.Services.Abstract
{
    public interface ILanguageService
    {
        #region Methods
        Task<ModelResponse<LanguageDto>> AddAsync(LanguageDto languageDto);
        Task<ModelResponse<LanguageDto>> UpdateAsync(LanguageDto languageDto);
        Task<ModelResponse<LanguageDto>> DeleteAsync(LanguageDto languageDto);
        Task<ModelResponse<LanguageDto>> DeleteAsync(int id);
        Task<ModelResponse<LanguageDto>> GetByIdAsync(int id);
        Task<PagedModelResponse<List<LanguageDto>>> GetAllAsync(ArchievesListRequestParameter parameter);
        #endregion
    }
}