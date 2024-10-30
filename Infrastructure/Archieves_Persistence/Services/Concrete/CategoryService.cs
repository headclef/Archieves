using Archieves_Application.Dtos;
using Archieves_Application.Interfaces.Repositories.Abstract;
using Archieves_Application.Interfaces.Services.Abstract;
using Archieves_Application.Parameters.Common;
using Archieves_Application.Wrappers;
using Archieves_Domain.Entities;
using AutoMapper;

namespace Archieves_Persistence.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        #region Properties
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion
        #region Methods
        public async Task<ModelResponse<CategoryDto>> AddAsync(CategoryDto dto)
        {
            try
            {
                // Map dto to entity
                var entity = _mapper.Map<Category>(dto);
                // Add entity to database
                var process = await _repository.AddAsync(entity);
                if (process is null)
                    // Return error response if process failed
                    return new ModelResponse<CategoryDto>().Fail("Failed to add category.");
                // Map entity to dto
                var result = _mapper.Map<CategoryDto>(process);
                // Return success response with data
                return new ModelResponse<CategoryDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<CategoryDto>().Fail($"Failed to add category. Here's the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<CategoryDto>> UpdateAsync(CategoryDto dto)
        {
            try
            {
                // Map dto to entity
                var entity = _mapper.Map<Category>(dto);
                if (entity is null)
                    // Return error response if entity not found
                    return new ModelResponse<CategoryDto>().Fail("Category not found.");
                // Update entity in database
                var process = await _repository.UpdateAsync(entity);
                if (process is null)
                    // Return error response if process failed
                    return new ModelResponse<CategoryDto>().Fail("Failed to update category.");
                // Map entity to dto
                var result = _mapper.Map<CategoryDto>(process);
                // Return success response with data
                return new ModelResponse<CategoryDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<CategoryDto>().Fail($"Failed to update category. Here's the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<CategoryDto>> DeleteAsync(CategoryDto dto)
        {
            try
            {
                // Map the dto to the entity
                var entity = _mapper.Map<Category>(dto);
                // Delete entity from database
                var process = await _repository.DeleteAsync(entity);
                if (!process)
                    // Return error response if process failed
                    return new ModelResponse<CategoryDto>().Fail("Failed to delete category.");
                // Return success response with data
                return new ModelResponse<CategoryDto>().Success();
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<CategoryDto>().Fail($"Failed to delete category. Here's the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<CategoryDto>> DeleteAsync(int id)
        {
            try
            {
                // Get entity by id
                var entity = await _repository.GetByIdAsync(id);
                if (entity is null)
                    // Return error response if entity not found
                    return new ModelResponse<CategoryDto>().Fail("Category not found.");
                // Delete entity from database
                var process = await _repository.DeleteAsync(id);
                if (!process)
                    // Return error response if process failed
                    return new ModelResponse<CategoryDto>().Fail("Failed to delete category.");
                // Return success response with data
                return new ModelResponse<CategoryDto>().Success();
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<CategoryDto>().Fail($"Failed to delete category. Here's the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<CategoryDto>> GetByIdAsync(int id)
        {
            try
            {
                // Get entity by id
                var entity = await _repository.GetByIdAsync(id);
                if (entity is null)
                    // Return error response if entity not found
                    return new ModelResponse<CategoryDto>().Fail("Category not found.");
                // Map entity to dto
                var result = _mapper.Map<CategoryDto>(entity);
                // Return success response with data
                return new ModelResponse<CategoryDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<CategoryDto>().Fail($"Failed to get category. Here's the error: {exception.Message}");
            }
        }

        public async Task<PagedModelResponse<List<CategoryDto>>> GetAllAsync(ArchievesListRequestParameter parameter)
        {
            try
            {
                // Get entities from database
                var entities = await _repository.GetAllAsync();
                if (entities is null)
                    // Return error response if entities not found
                    return new PagedModelResponse<List<CategoryDto>>().Fail("Categories not found.");
                // Map entities to dtos
                var dtos = _mapper.Map<List<CategoryDto>>(entities);
                // Return success response with data
                return new PagedModelResponse<List<CategoryDto>>().Success(dtos, (int)parameter.PageNumber, (int)parameter.PageSize, (int)(dtos.Count / parameter.PageSize) + 1, dtos.Count);
            }
            catch (Exception exception)
            {
                // Log exception
                return new PagedModelResponse<List<CategoryDto>>().Fail($"Failed to get categories. Here's the error: {exception.Message}");
            }
        }
        #endregion
    }
}