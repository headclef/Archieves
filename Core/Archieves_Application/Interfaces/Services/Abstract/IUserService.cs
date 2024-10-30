using Archieves_Application.Dtos;
using Archieves_Application.Parameters.Common;
using Archieves_Application.Wrappers;

namespace Archieves_Application.Interfaces.Services.Abstract
{
    public interface IUserService
    {
        #region Methods
        Task<ModelResponse<UserDto>> AddAsync(UserDto userDto);
        Task<ModelResponse<UserDto>> UpdateAsync(UserDto userDto);
        Task<ModelResponse<UserDto>> DeleteAsync(UserDto userDto);
        Task<ModelResponse<UserDto>> DeleteAsync(int id);
        Task<ModelResponse<UserDto>> GetByIdAsync(int id);
        Task<PagedModelResponse<List<UserDto>>> GetAllAsync(ArchievesListRequestParameter parameter);
        #endregion
    }
}