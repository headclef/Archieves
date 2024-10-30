using Archieves_Application.Dtos;
using Archieves_Application.Interfaces.Repositories.Abstract;
using Archieves_Application.Interfaces.Services.Abstract;
using Archieves_Application.Parameters.Common;
using Archieves_Application.Wrappers;
using Archieves_Domain.Entities;
using AutoMapper;

namespace Archieves_Persistence.Services.Concrete
{
    public class GenderService : IGenderService
    {
        #region Properties
        private readonly IGenderRepository _repository;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public GenderService(IGenderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion
        #region Methods
        public async Task<ModelResponse<GenderDto>> AddAsync(GenderDto dto)
        {
            try
            {
                // Map dto to entity
                var entity = _mapper.Map<Gender>(dto);
                // Add entity to database
                var process = await _repository.AddAsync(entity);
                if (process is null)
                    // Return error response if process failed
                    return new ModelResponse<GenderDto>().Fail("Failed to add gender.");
                // Map entity to dto
                var result = _mapper.Map<GenderDto>(process);
                // Return success response with data
                return new ModelResponse<GenderDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<GenderDto>().Fail($"Failed to add category. Here's the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<GenderDto>> UpdateAsync(GenderDto dto)
        {
            try
            {
                // Map dto to entity
                var entity = _mapper.Map<Gender>(dto);
                if (entity is null)
                    // Return error response if entity not found
                    return new ModelResponse<GenderDto>().Fail("Category not found.");
                // Update entity in database
                var process = await _repository.UpdateAsync(entity);
                if (process is null)
                    // Return error response if process failed
                    return new ModelResponse<GenderDto>().Fail("Failed to update category.");
                // Map entity to dto
                var result = _mapper.Map<GenderDto>(process);
                // Return success response with data
                return new ModelResponse<GenderDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<GenderDto>().Fail($"Failed to update category. Here's the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<GenderDto>> DeleteAsync(GenderDto dto)
        {
            try
            {
                // Map the dto to the entity
                var entity = _mapper.Map<Gender>(dto);
                // Delete entity from database
                var process = await _repository.DeleteAsync(entity);
                if (!process)
                    // Return error response if process failed
                    return new ModelResponse<GenderDto>().Fail("Failed to delete category.");
                // Return success response with data
                return new ModelResponse<GenderDto>().Success();
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<GenderDto>().Fail($"Failed to delete category. Here's the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<GenderDto>> DeleteAsync(int id)
        {
            try
            {
                // Get entity by id
                var entity = await _repository.GetByIdAsync(id);
                if (entity is null)
                    // Return error response if entity not found
                    return new ModelResponse<GenderDto>().Fail("Category not found.");
                // Delete entity from database
                var process = await _repository.DeleteAsync(id);
                if (!process)
                    // Return error response if process failed
                    return new ModelResponse<GenderDto>().Fail("Failed to delete category.");
                // Return success response with data
                return new ModelResponse<GenderDto>().Success();
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<GenderDto>().Fail($"Failed to delete category. Here's the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<GenderDto>> GetByIdAsync(int id)
        {
            try
            {
                // Get entity by id
                var entity = await _repository.GetByIdAsync(id);
                if (entity is null)
                    // Return error response if entity not found
                    return new ModelResponse<GenderDto>().Fail("Category not found.");
                // Map entity to dto
                var result = _mapper.Map<GenderDto>(entity);
                // Return success response with data
                return new ModelResponse<GenderDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<GenderDto>().Fail($"Failed to get category. Here's the error: {exception.Message}");
            }
        }

        public async Task<PagedModelResponse<List<GenderDto>>> GetAllAsync(ArchievesListRequestParameter parameter)
        {
            try
            {
                // Get entities from database
                var entities = await _repository.GetAllAsync();
                if (entities is null)
                    // Return error response if entities not found
                    return new PagedModelResponse<List<GenderDto>>().Fail("Categories not found.");
                // Map entities to dtos
                var dtos = _mapper.Map<List<GenderDto>>(entities);
                // Return success response with data
                return new PagedModelResponse<List<GenderDto>>().Success(dtos, (int)parameter.PageNumber, (int)parameter.PageSize, (int)(dtos.Count / parameter.PageSize) + 1, dtos.Count);
            }
            catch (Exception exception)
            {
                // Log exception
                return new PagedModelResponse<List<GenderDto>>().Fail($"Failed to get categories. Here's the error: {exception.Message}");
            }
        }
        #endregion
    }
}