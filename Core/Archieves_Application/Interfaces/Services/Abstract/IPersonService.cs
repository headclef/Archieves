using Archieves_Application.Dtos;
using Archieves_Application.Parameters.Common;
using Archieves_Application.Wrappers;

namespace Archieves_Application.Interfaces.Services.Abstract
{
    public interface IPersonService
    {
        #region Methods
        Task<ModelResponse<PersonDto>> AddAsync(PersonDto personDto);
        Task<ModelResponse<PersonDto>> UpdateAsync(PersonDto personDto);
        Task<ModelResponse<PersonDto>> DeleteAsync(PersonDto personDto);
        Task<ModelResponse<PersonDto>> DeleteAsync(int id);
        Task<ModelResponse<PersonDto>> GetByIdAsync(int id);
        Task<PagedModelResponse<List<PersonDto>>> GetAllAsync(ArchievesListRequestParameter parameter);
        #endregion
    }
}