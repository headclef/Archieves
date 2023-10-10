using Archieves.Kutuphane.Models.Subscriber;
using Archieves.Kutuphane.Models.Wrappers;

namespace Archieves.Kutuphane.Services.Abstractions
{
    public interface ISubscriberService
    {
        Task<ModelResponse<SubscriberViewModel>> AddSubscriberModelAsync(SubscriberAddModel model);
        Task<ModelResponse<SubscriberViewModel>> UpdateSubscriberModelAsync(SubscriberUpdateModel model);
        Task<ModelResponse<SubscriberViewModel>> DeleteSubscriberModelAsync(int id);
        Task<ModelResponse<SubscriberViewModel>> GetSubscriberByIdAsync(int id);
    }
}
