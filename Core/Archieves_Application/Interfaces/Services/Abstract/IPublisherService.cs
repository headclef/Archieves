using Archieves_Application.Dtos;
using Archieves_Application.Parameters.Common;
using Archieves_Application.Wrappers;

namespace Archieves_Application.Interfaces.Services.Abstract
{
    public interface IPublisherService
    {
        #region Methods
        Task<ModelResponse<PublisherDto>> AddAsync(PublisherDto publisherDto);
        Task<ModelResponse<PublisherDto>> UpdateAsync(PublisherDto publisherDto);
        Task<ModelResponse<PublisherDto>> DeleteAsync(PublisherDto publisherDto);
        Task<ModelResponse<PublisherDto>> DeleteAsync(int id);
        Task<ModelResponse<PublisherDto>> GetByIdAsync(int id);
        Task<PagedModelResponse<List<PublisherDto>>> GetAllAsync(ArchievesListRequestParameter parameter);
        #endregion
    }
}