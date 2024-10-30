using Archieves_Application.Dtos;
using Archieves_Application.Interfaces.Repositories.Abstract;
using Archieves_Application.Interfaces.Services.Abstract;
using Archieves_Application.Parameters.Common;
using Archieves_Application.Wrappers;
using Archieves_Domain.Entities;
using AutoMapper;

namespace Archieves_Persistence.Services.Concrete
{
    public class BookCategoryService : IBookCategoryService
    {
        #region Properties
        private readonly IBookCategoryRepository _repository;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public BookCategoryService(IBookCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion
        #region Methods
        public async Task<ModelResponse<BookCategoryDto>> AddAsync(BookCategoryDto dto)
        {
            try
            {
                // Map dto to entity
                var entity = _mapper.Map<BookCategory>(dto);
                // Add entity to database
                var process = await _repository.AddAsync(entity);
                if (process is null)
                    // Return error response if process failed
                    return new ModelResponse<BookCategoryDto>().Fail("Failed to add book category");
                // Map entity to dto
                var bookCategoryDto = _mapper.Map<BookCategoryDto>(process);
                // Return success response with data
                return new ModelResponse<BookCategoryDto>().Success(bookCategoryDto);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<BookCategoryDto>().Fail($"Failed to add book category: {exception.Message}");
            }
        }

        public async Task<ModelResponse<BookCategoryDto>> UpdateAsync(BookCategoryDto dto)
        {
            try
            {
                // Map dto to entity
                var entity = _mapper.Map<BookCategory>(dto);
                // Update entity in database
                var process = await _repository.UpdateAsync(entity);
                if (process is null)
                    // Return error response if process failed
                    return new ModelResponse<BookCategoryDto>().Fail("Failed to update book category");
                // Map entity to dto
                var bookCategoryDto = _mapper.Map<BookCategoryDto>(process);
                // Return success response with data
                return new ModelResponse<BookCategoryDto>().Success(bookCategoryDto);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<BookCategoryDto>().Fail($"Failed to update book category: {exception.Message}");
                #endregion
            }
        }

        public async Task<ModelResponse<BookCategoryDto>> DeleteAsync(BookCategoryDto dto)
        {
            try
            {
                // Map the dto to the entity
                var entity = _mapper.Map<BookCategory>(dto);
                // Send data to repository
                var process = await _repository.DeleteAsync(entity);
                if (!process)
                    // Return error response if process failed
                    return new ModelResponse<BookCategoryDto>().Fail("Failed to delete book category");
                // Return result
                return new ModelResponse<BookCategoryDto>().Success();
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<BookCategoryDto>().Fail($"Failed to delete book category: {exception.Message}");
            }
        }

        public async Task<ModelResponse<BookCategoryDto>> DeleteAsync(int id)
        {
            try
            {
                // Check if book category exists
                var entity = await _repository.GetByIdAsync(id);
                if (entity is null)
                    // Return error response if book category not exists
                    return new ModelResponse<BookCategoryDto>().Fail("Book category not found");
                // Send data to repository
                var process = await _repository.DeleteAsync(id);
                if (!process)
                    // Return error response if process failed
                    return new ModelResponse<BookCategoryDto>().Fail("Failed to delete book category");
                // Return result
                return new ModelResponse<BookCategoryDto>().Success();
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<BookCategoryDto>().Fail($"Failed to delete book category: {exception.Message}");
            }
        }

        public async Task<ModelResponse<BookCategoryDto>> GetByIdAsync(int id)
        {
            try
            {
                // Get data from repository
                var entity = await _repository.GetByIdAsync(id);
                if (entity is null)
                    // Return error response if entity not exists
                    return new ModelResponse<BookCategoryDto>().Fail("Book category not found");
                // Map entity to dto
                var dto = _mapper.Map<BookCategoryDto>(entity);
                // Return success response with data
                return new ModelResponse<BookCategoryDto>().Success(dto);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<BookCategoryDto>().Fail($"Failed to get book category: {exception.Message}");
            }
        }

        public async Task<PagedModelResponse<List<BookCategoryDto>>> GetAllAsync(ArchievesListRequestParameter parameter)
        {
            try
            {
                // Get data from repository
                var entities = await _repository.GetAllAsync();
                if (entities is null)
                    // Return error response if entities not exists
                    return new PagedModelResponse<List<BookCategoryDto>>().Fail("Book categories not found");
                // Map entities to dtos
                var dtos = _mapper.Map<List<BookCategoryDto>>(entities);
                // Return success response with data
                return new PagedModelResponse<List<BookCategoryDto>>().Success(dtos, (int)parameter.PageNumber, (int)parameter.PageSize, (int)(dtos.Count / parameter.PageSize) + 1, dtos.Count);
            }
            catch (Exception exception)
            {
                // Log exception
                return new PagedModelResponse<List<BookCategoryDto>>().Fail($"Failed to get book categories: {exception.Message}");
            }
        }
    }
}