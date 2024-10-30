using Archieves_Application.Dtos;
using Archieves_Application.Interfaces.Repositories.Abstract;
using Archieves_Application.Interfaces.Services.Abstract;
using Archieves_Application.Parameters.Common;
using Archieves_Application.Wrappers;
using Archieves_Domain.Entities;
using AutoMapper;

namespace Archieves_Persistence.Services.Concrete
{
    public class LanguageService : ILanguageService
    {
        #region Properties
        private readonly ILanguageRepository _repository;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public LanguageService(ILanguageRepository repository, IMapper mappper)
        {
            _repository = repository;
            _mapper = mappper;
        }
        #endregion
        #region Methods
        public async Task<ModelResponse<LanguageDto>> AddAsync(LanguageDto dto)
        {
            try
            {
                // Map dto to entity
                var entity = _mapper.Map<Language>(dto);
                // Add entity to database
                var process = await _repository.AddAsync(entity);
                if (process is null)
                    // Return error response if process failed
                    return new ModelResponse<LanguageDto>().Fail("Failed to add language.");
                // Map entity to dto
                var result = _mapper.Map<LanguageDto>(process);
                // Return success response with data
                return new ModelResponse<LanguageDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<LanguageDto>().Fail($"Failed to add language. Here's the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<LanguageDto>> UpdateAsync(LanguageDto dto)
        {
            try
            {
                // Map dto to entity
                var entity = _mapper.Map<Language>(dto);
                if (entity is null)
                    // Return error response if entity not found
                    return new ModelResponse<LanguageDto>().Fail("Language not found.");
                // Update entity in database
                var process = await _repository.UpdateAsync(entity);
                if (process is null)
                    // Return error response if process failed
                    return new ModelResponse<LanguageDto>().Fail("Failed to update language.");
                // Map entity to dto
                var result = _mapper.Map<LanguageDto>(process);
                // Return success response with data
                return new ModelResponse<LanguageDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<LanguageDto>().Fail($"Failed to update language. Here's the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<LanguageDto>> DeleteAsync(LanguageDto dto)
        {
            try
            {
                // Map the dto to the entity
                var entity = _mapper.Map<Language>(dto);
                // Delete entity from database
                var process = await _repository.DeleteAsync(entity);
                if (!process)
                    // Return error response if process failed
                    return new ModelResponse<LanguageDto>().Fail("Failed to delete language.");
                // Map entity to dto
                var result = _mapper.Map<LanguageDto>(process);
                // Return success response with data
                return new ModelResponse<LanguageDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<LanguageDto>().Fail($"Failed to delete language. Here's the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<LanguageDto>> DeleteAsync(int id)
        {
            try
            {
                // Get entity by id
                var entity = await _repository.GetByIdAsync(id);
                if (entity is null)
                    // Return error response if entity not found
                    return new ModelResponse<LanguageDto>().Fail("Language not found.");
                // Delete entity from database
                var process = await _repository.DeleteAsync(id);
                if (!process)
                    // Return error response if process failed
                    return new ModelResponse<LanguageDto>().Fail("Failed to delete language.");
                // Map entity to dto
                var result = _mapper.Map<LanguageDto>(process);
                // Return success response with data
                return new ModelResponse<LanguageDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<LanguageDto>().Fail($"Failed to delete language. Here's the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<LanguageDto>> GetByIdAsync(int id)
        {
            try
            {
                // Get entity by id
                var entity = await _repository.GetByIdAsync(id);
                if (entity is null)
                    // Return error response if entity not found
                    return new ModelResponse<LanguageDto>().Fail("Language not found.");
                // Map entity to dto
                var result = _mapper.Map<LanguageDto>(entity);
                // Return success response with data
                return new ModelResponse<LanguageDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<LanguageDto>().Fail($"Failed to get language. Here's the error: {exception.Message}");
            }
        }

        public async Task<PagedModelResponse<List<LanguageDto>>> GetAllAsync(ArchievesListRequestParameter parameter)
        {
            try
            {
                // Get data from repository
                var entities = await _repository.GetAllAsync();
                if (entities is null)
                    // Return error response if data is null
                    return new PagedModelResponse<List<LanguageDto>>().Fail("Failed to get languages");
                // Map entities to dtos
                var dtos = _mapper.Map<List<LanguageDto>>(entities);
                // Return success response with data
                return new PagedModelResponse<List<LanguageDto>>().Success(dtos, (int)parameter.PageNumber, (int)parameter.PageSize, (int)(dtos.Count / parameter.PageSize) + 1, dtos.Count);
            }
            catch (Exception exception)
            {
                // Log exception
                return new PagedModelResponse<List<LanguageDto>>().Fail($"Failed to get languages. Here's the error: {exception.Message}");
            }
        }
        #endregion
    }
}