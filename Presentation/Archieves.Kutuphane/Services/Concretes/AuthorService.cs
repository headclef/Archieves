using Archieves.Application.Repositories;
using Archieves.Domain.Entities;
using Archieves.Kutuphane.Models.Author;
using Archieves.Kutuphane.Models.Wrappers;
using Archieves.Kutuphane.Services.Abstractions;
using Archieves.Persistence.Repositories;
using AutoMapper;

namespace Archieves.Kutuphane.Services.Concretes
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<ModelResponse<AuthorViewModel>> AddAuthorModelAsync(AuthorAddModel model)
        {
            var result = new ModelResponse<AuthorViewModel>();
            try
            {
                var author = _mapper.Map<Author>(model);
                var insertResult = await _authorRepository.AddAsync(author);
                var authorViewModel = _mapper.Map<AuthorViewModel>(insertResult);
                return result.Success(authorViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
        public async Task<ModelResponse<AuthorViewModel>> DeleteAuthorModelAsync(int id)
        {
            var result = new ModelResponse<AuthorViewModel>();
            try
            {
                var author = await _authorRepository.GetByIdAsync(id);
                var deleteResult = await _authorRepository.DeleteAsync(author);
                var authorViewModel = _mapper.Map<AuthorViewModel>(deleteResult);
                return result.Success(authorViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
        public async Task<ModelResponse<AuthorViewModel>> GetAuthorByIdAsync(int id)
        {
            var result = new ModelResponse<AuthorViewModel>();
            try
            {
                var author = await _authorRepository.GetByIdAsync(id);
                var authorViewModel = _mapper.Map<AuthorViewModel>(author);
                return result.Success(authorViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }
        public async Task<ModelResponse<AuthorViewModel>> UpdateAuthorModelAsync(AuthorUpdateModel model)
        {
            var result = new ModelResponse<AuthorViewModel>();
            try
            {
                var author = _mapper.Map<Author>(model);
                var updateResult = _authorRepository.UpdateAsync(author);
                var authorViewModel = _mapper.Map<AuthorViewModel>(updateResult);
                return result.Success(authorViewModel);
            }
            catch (Exception e)
            {
                return result.Fail($"An error occured: {e.Message}.");
            }
        }   
    }
}