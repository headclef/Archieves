using Archieves.Kutuphane.Models.User;
using Archieves.Kutuphane.Models.Wrappers;

namespace Archieves.Kutuphane.Services.Abstractions
{
    public interface IUserService
    {
        Task<ModelResponse<UserViewModel>> AddUserAsync(UserAddModel model);
        Task<ModelResponse<UserViewModel>> UpdateUserAsync(UserUpdateModel model);
        Task<ModelResponse<UserViewModel>> DeleteUserAsync(int id);
        Task<ModelResponse<UserViewModel>> GetUserByIdAsync(int id);
        Task<ModelResponse<UserViewModel>> GetUserByEmailAsync(string email);
        Task<ModelResponse<UserViewModel>> GetUserByEmailandPasswordAsync(UserViewModel model);
        Task<ModelResponse<List<UserViewModel>>> GetAllUsersAsync();
    }
}
