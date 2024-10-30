using Archieves_Application.Dtos;
using Archieves_Application.Parameters.Common;
using Archieves_Application.Wrappers;

namespace Archieves_Application.Interfaces.Services.Abstract
{
    public interface IGenderService
    {
        #region Methods
        Task<ModelResponse<GenderDto>> AddAsync(GenderDto genderDto);
        Task<ModelResponse<GenderDto>> UpdateAsync(GenderDto genderDto);
        Task<ModelResponse<GenderDto>> DeleteAsync(GenderDto genderDto);
        Task<ModelResponse<GenderDto>> DeleteAsync(int id);
        Task<ModelResponse<GenderDto>> GetByIdAsync(int id);
        Task<PagedModelResponse<List<GenderDto>>> GetAllAsync(ArchievesListRequestParameter parameter);
        #endregion
    }
}