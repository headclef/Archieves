using Archieves.Application.Repositories;
using Archieves.Domain.Entities;
using Archieves.Kutuphane.Models.Subscriber;
using Archieves.Kutuphane.Models.Wrappers;
using Archieves.Kutuphane.Services.Abstractions;
using AutoMapper;

namespace Archieves.Kutuphane.Services.Concretes
{
    public class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IMapper _mapper;
        public SubscriberService(ISubscriberRepository subscriberRepository, IMapper mapper)
        {
            _subscriberRepository = subscriberRepository;
            _mapper = mapper;
        }
        public async Task<ModelResponse<SubscriberViewModel>> AddSubscriberModelAsync(SubscriberAddModel model)
        {
            var result = new ModelResponse<SubscriberViewModel>();
            try
            {
                var subscriber = _mapper.Map<Subscriber>(model);
                var insertResult = await _subscriberRepository.AddAsync(subscriber);
                var subscriberViewModel = _mapper.Map<SubscriberViewModel>(insertResult);
                return result.Success(subscriberViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
        public async Task<ModelResponse<SubscriberViewModel>> DeleteSubscriberModelAsync(int id)
        {
            var result = new ModelResponse<SubscriberViewModel>();
            try
            {
                var subscriber = await _subscriberRepository.GetByIdAsync(id);
                if (subscriber is null)
                {
                    return result.Fail($"No subscriber found with id {id}.");
                }
                /* Önemli Not:
                 * Eğer silinecek olan kayı veritabanından tamamen silinmek istenmiyor, sadece aktiflik durumu değiştirilmek isteniyorsa;
                 * 
                 *                          ESKİ HALİ                       |                   YENİ HALİ
                 *                                                          |
                 *                                                          |   subscriber.Status = false;
                 * await _subscriberRepository.DeleteAsync(subscriber);     |   await _subscriberRepository.UpdateAsync(subscriber);
                 * 
                 * Şeklinde bir yöntem izlenebilir.
                 */
                var deleteResult = await _subscriberRepository.DeleteAsync(subscriber);
                var subscriberViewModel = _mapper.Map<SubscriberViewModel>(deleteResult);
                return result.Success(subscriberViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
        public async Task<ModelResponse<SubscriberViewModel>> GetSubscriberByIdAsync(int id)
        {
            var result = new ModelResponse<SubscriberViewModel>();
            try
            {
                var subscriber = await _subscriberRepository.GetByIdAsync(id);
                if (subscriber is null)
                {
                    return result.Fail($"No subscriber found with id {id}.");
                }
                var subscriberViewModel = _mapper.Map<SubscriberViewModel>(subscriber);
                return result.Success(subscriberViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
        public async Task<ModelResponse<SubscriberViewModel>> UpdateSubscriberModelAsync(SubscriberUpdateModel model)
        {
            var result = new ModelResponse<SubscriberViewModel>();
            try
            {
                var subscriber = _mapper.Map<Subscriber>(model);
                var updateResult = await _subscriberRepository.UpdateAsync(subscriber);
                var subscriberViewModel = _mapper.Map<SubscriberViewModel>(updateResult);
                return result.Success(subscriberViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
    }
}