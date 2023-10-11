using Archieves.Kutuphane.Models.Rating;
using Archieves.Kutuphane.Models.Wrappers;

namespace Archieves.Kutuphane.Services.Abstractions
{
    public interface IRatingService
    {
        Task<ModelResponse<RatingViewModel>> AddRatingAsync(RatingAddModel model);
        Task<ModelResponse<RatingViewModel>> UpdateRatingAsync(RatingUpdateModel model);
        Task<ModelResponse<RatingViewModel>> DeleteRatingAsync(int id);
        Task<ModelResponse<RatingViewModel>> GetRatingByIdAsync(int id);
        Task<ModelResponse<List<RatingViewModel>>> GetAllRatingsAsync();
        Task<ModelResponse<List<RatingViewModel>>> GetAllRatingsByBookIdAsync(int bookId);
    }
}
