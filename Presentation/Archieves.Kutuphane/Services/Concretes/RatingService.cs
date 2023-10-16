using Archieves.Application.Repositories;
using Archieves.Domain.Entities;
using Archieves.Kutuphane.Models.Rating;
using Archieves.Kutuphane.Models.Wrappers;
using Archieves.Kutuphane.Services.Abstractions;
using AutoMapper;

namespace Archieves.Kutuphane.Services.Concretes
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;
        public RatingService(IRatingRepository ratingRepository, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
        }
        public async Task<ModelResponse<RatingViewModel>> AddRatingAsync(RatingAddModel model)
        {
            var result = new ModelResponse<RatingViewModel>();
            try
            {
                var rating = _mapper.Map<Rating>(model);
                var addedRating = await _ratingRepository.AddAsync(rating);
                var ratingViewModel = _mapper.Map<RatingViewModel>(addedRating);
                return result.Success(ratingViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }

        public async Task<ModelResponse<RatingViewModel>> DeleteRatingAsync(int id)
        {
            var result = new ModelResponse<RatingViewModel>();
            try
            {
                var rating = await _ratingRepository.GetByIdAsync(id);
                var deleteResult = await _ratingRepository.DeleteAsync(rating);
                var ratingViewModel = _mapper.Map<RatingViewModel>(deleteResult);
                return result.Success(ratingViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }

        public async Task<ModelResponse<List<RatingViewModel>>> GetAllRatingsAsync()
        {
            var result = new ModelResponse<List<RatingViewModel>>();
            try
            {
                var ratings = _ratingRepository.GetAllAsync().Result.ToList();
                var ratingViewModels = _mapper.Map<List<RatingViewModel>>(ratings);
                return result.Success(ratingViewModels);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }

        public async Task<ModelResponse<List<RatingViewModel>>> GetAllRatingsByBookIdAsync(int bookId)
        {
            var result = new ModelResponse<List<RatingViewModel>>();
            try
            {
                var ratings = _ratingRepository.GetAllAsync().Result.Where(x => x.BookId == bookId).ToList();
                var ratingViewModels = _mapper.Map<List<RatingViewModel>>(ratings);
                return result.Success(ratingViewModels);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }

        public async Task<ModelResponse<RatingViewModel>> GetRatingByIdAsync(int id)
        {
            var result = new ModelResponse<RatingViewModel>();
            try
            {
                var rating = _ratingRepository.GetByIdAsync(id);
                var ratingViewModel = _mapper.Map<RatingViewModel>(rating);
                return result.Success(ratingViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }

        public async Task<ModelResponse<RatingViewModel>> UpdateRatingAsync(RatingUpdateModel model)
        {
            var result = new ModelResponse<RatingViewModel>();
            try
            {
                var rating = _mapper.Map<Rating>(model);
                var updateResult = await _ratingRepository.UpdateAsync(rating);
                var ratingViewModel = _mapper.Map<RatingViewModel>(updateResult);
                return result.Success(ratingViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
    }
}
