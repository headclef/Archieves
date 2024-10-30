using Archieves_Application.Dtos;
using Archieves_Application.Interfaces.Repositories.Abstract;
using Archieves_Application.Interfaces.Services.Abstract;
using Archieves_Application.Parameters.Common;
using Archieves_Application.Wrappers;
using Archieves_Domain.Entities;
using AutoMapper;
using System;
using System.Reflection.Metadata;

namespace Archieves_Persistence.Services.Concrete
{
    public class AuthorService : IAuthorService
    {
        #region Properties
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion
        #region Methods
        public async Task<ModelResponse<AuthorDto>> AddAsync(AuthorDto dto)
        {
            try
            {
                // Map dto to entity
                var author = _mapper.Map<Author>(dto);
                // Send data to repository
                var process = await _repository.AddAsync(author);
                if (process is null)
                    // Return error response if process failed
                    return new ModelResponse<AuthorDto>().Fail("Failed to add author");
                // Map entity to dto
                var authorDto = _mapper.Map<AuthorDto>(process);
                // Return success response with data
                return new ModelResponse<AuthorDto>().Success(authorDto);

            }
            catch (Exception exception)
            {
                // Log exception
                // TO DO: LOGGING
                // Return error if exception
                return new ModelResponse<AuthorDto>().Fail($"Failed to add author. Here is the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<AuthorDto>> UpdateAsync(AuthorDto dto)
        {
            try
            {
                // Check if author exists
                var authorExists = await _repository.GetByIdAsync(dto.Id);
                if (authorExists is null)
                    // Return error response if author not exists
                    return new ModelResponse<AuthorDto>().Fail("Author not found");
                // Map dto to entity
                var author = _mapper.Map<Author>(dto);
                // Send data to repository
                var process = await _repository.UpdateAsync(author);
                if (process is null)
                    // Return error response if process failed
                    return new ModelResponse<AuthorDto>().Fail("Failed to update author");
                // Map entity to dto
                var authorDto = _mapper.Map<AuthorDto>(process);
                // Return success response with data
                return new ModelResponse<AuthorDto>().Success(authorDto);
            }
            catch (Exception exception)
            {
                // Log exception
                // TO DO: LOGGING
                // Return error if exception
                return new ModelResponse<AuthorDto>().Fail($"Failed to update author. Here is the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<AuthorDto>> DeleteAsync(AuthorDto dto)
        {
            try
            {
                // Map the dto to the entity
                var entity = _mapper.Map<Author>(dto);
                // Send data to repository
                var process = await _repository.DeleteAsync(entity);
                if (!process)
                    // Return error response if process failed
                    return new ModelResponse<AuthorDto>().Fail("Failed to delete author");
                // Return result
                return new ModelResponse<AuthorDto>().Success();
            }
            catch (Exception exception)
            {
                // Log exception
                // TO DO: LOGGING
                // Return error if exception
                return new ModelResponse<AuthorDto>().Fail($"Failed to delete author. Here is the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<AuthorDto>> DeleteAsync(int id)
        {
            try
            {
                // Check if author exists
                var authorExists = await _repository.GetByIdAsync(id);
                if (authorExists is null)
                    // Return error response if author not exists
                    return new ModelResponse<AuthorDto>().Fail("Author not found");
                // Send data to repository
                var process = await _repository.DeleteAsync(id);
                if (!process)
                    // Return error response if process failed
                    return new ModelResponse<AuthorDto>().Fail("Failed to delete author");
                // Return result
                return new ModelResponse<AuthorDto>().Success();
            }
            catch (Exception exception)
            {
                // Log exception
                // TO DO: LOGGING
                // Return error if exception
                return new ModelResponse<AuthorDto>().Fail($"Failed to delete author. Here is the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<AuthorDto>> GetByIdAsync(int id)
        {
            try
            {
                // Get data from repository
                var author = await _repository.GetByIdAsync(id);
                if (author is null)
                    // Return error response if data is null
                    return new ModelResponse<AuthorDto>().Fail("Author not found");
                // Map entity to dto
                var authorDto = _mapper.Map<AuthorDto>(author);
                // Return success response with data
                return new ModelResponse<AuthorDto>().Success(authorDto);
            }
            catch (Exception exception)
            {
                // Log exception
                // TO DO: LOGGING
                // Return false if exception
                return null;
            }
        }

        public async Task<PagedModelResponse<List<AuthorDto>>> GetAllAsync(ArchievesListRequestParameter parameter)
        {
            try
            {
                // Get data from repository
                var authors = await _repository.GetAllAsync();
                if (authors is null)
                    // Return error response if data is null
                    return new PagedModelResponse<List<AuthorDto>>().Fail("Failed to get authors");
                // Map entities to dtos
                var dtos = _mapper.Map<List<AuthorDto>>(authors);
                // Return success response with data
                return new PagedModelResponse<List<AuthorDto>>().Success(dtos, (int)parameter.PageNumber, (int)parameter.PageSize, (int)(dtos.Count / parameter.PageSize) + 1, dtos.Count);
            }
            catch (Exception exception)
            {
                // Log exception
                // TO DO: LOGGING
                // Return false if exception
                return new PagedModelResponse<List<AuthorDto>>().Fail($"Failed to get authors. Here is the error: {exception.Message}");
            }
        }
        #endregion
    }
}