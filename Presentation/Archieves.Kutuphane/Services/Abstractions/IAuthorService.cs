using Archieves.Kutuphane.Models.Author;
using Archieves.Kutuphane.Models.Wrappers;

namespace Archieves.Kutuphane.Services.Abstractions
{
    public interface IAuthorService
    {
        Task<ModelResponse<AuthorViewModel>> AddAuthorModelAsync(AuthorAddModel model);
        Task<ModelResponse<AuthorViewModel>> UpdateAuthorModelAsync(AuthorUpdateModel model);
        Task<ModelResponse<AuthorViewModel>> DeleteAuthorModelAsync(int id);
        Task<ModelResponse<AuthorViewModel>> GetAuthorByIdAsync(int id);
    }
}
