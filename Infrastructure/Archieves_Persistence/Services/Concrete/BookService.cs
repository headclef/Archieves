using Archieves_Application.Dtos;
using Archieves_Application.Interfaces.Repositories.Abstract;
using Archieves_Application.Interfaces.Services.Abstract;
using Archieves_Application.Parameters.Common;
using Archieves_Application.Wrappers;
using Archieves_Domain.Entities;
using AutoMapper;

namespace Archieves_Persistence.Services.Concrete
{
    public class BookService : IBookService
    {
        #region Properties
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        #endregion
        #region Methods
        public async Task<ModelResponse<BookDto>> AddAsync(BookDto dto)
        {
            try
            {
                // Map dto to entity
                var entity = _mapper.Map<Book>(dto);
                // Add entity to database
                var process = await _bookRepository.AddAsync(entity);
                if (process is null)
                    // Return error response if process failed
                    return new ModelResponse<BookDto>().Fail("Failed to add book");
                // Map entity to dto
                var result = _mapper.Map<BookDto>(process);
                // Return success response with data
                return new ModelResponse<BookDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<BookDto>().Fail($"Failed to add book. Here's the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<BookDto>> UpdateAsync(BookDto dto)
        {
            try
            {
                // Get entity by id
                var entity = await _bookRepository.GetByIdAsync(dto.Id);
                if (entity is null)
                    // Return error response if entity not found
                    return new ModelResponse<BookDto>().Fail("Book not found");
                // Map dto to entity
                entity = _mapper.Map(dto, entity);
                // Update entity in database
                var process = await _bookRepository.UpdateAsync(entity);
                if (process is null)
                    // Return error response if process failed
                    return new ModelResponse<BookDto>().Fail("Failed to update book");
                // Map entity to dto
                var result = _mapper.Map<BookDto>(process);
                // Return success response with data
                return new ModelResponse<BookDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<BookDto>().Fail($"Failed to update book. Here's the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<BookDto>> DeleteAsync(BookDto dto)
        {
            try
            {
                // Map the dto to the entity
                var entity = _mapper.Map<Book>(dto);
                // Delete entity from database
                var process = await _bookRepository.DeleteAsync(entity);
                if (!process)
                    // Return error response if process failed
                    return new ModelResponse<BookDto>().Fail("Failed to delete book");
                // Map entity to dto
                var result = _mapper.Map<BookDto>(entity);
                // Return success response with data
                return new ModelResponse<BookDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<BookDto>().Fail($"Failed to delete book. Here's the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<BookDto>> DeleteAsync(int id)
        {
            try
            {
                // Get entity by id
                var entity = await _bookRepository.GetByIdAsync(id);
                if (entity is null)
                    // Return error response if entity not found
                    return new ModelResponse<BookDto>().Fail("Book not found");
                // Delete entity from database
                var process = await _bookRepository.DeleteAsync(entity);
                if (!process)
                    // Return error response if process failed
                    return new ModelResponse<BookDto>().Fail("Failed to delete book");
                // Map entity to dto
                var result = _mapper.Map<BookDto>(entity);
                // Return success response with data
                return new ModelResponse<BookDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<BookDto>().Fail($"Failed to delete book. Here's the error: {exception.Message}");
            }
        }

        public async Task<ModelResponse<BookDto>> GetByIdAsync(int id)
        {
            try
            {
                // Get entity by id
                var entity = await _bookRepository.GetByIdAsync(id);
                if (entity is null)
                    // Return error response if entity not found
                    return new ModelResponse<BookDto>().Fail("Book not found");
                // Map entity to dto
                var result = _mapper.Map<BookDto>(entity);
                // Return success response with data
                return new ModelResponse<BookDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<BookDto>().Fail($"Failed to get book. Here's the error: {exception.Message}");
            }
        }

        public async Task<PagedModelResponse<List<BookDto>>> GetAllAsync(ArchievesListRequestParameter parameter)
        {
            try
            {
                // Get entities from database
                var entities = await _bookRepository.GetAllAsync();
                if (entities is null)
                    // Return error response if entities not found
                    return new PagedModelResponse<List<BookDto>>().Fail("Books not found");
                // Map entities to dtos
                var dtos = _mapper.Map<List<BookDto>>(entities);
                // Return success response with data
                return new PagedModelResponse<List<BookDto>>().Success(dtos, (int)parameter.PageNumber, (int)parameter.PageSize, (int)(dtos.Count / parameter.PageSize) + 1, dtos.Count);
            }
            catch (Exception exception)
            {
                // Log exception
                return new PagedModelResponse<List<BookDto>>().Fail($"Failed to get books. Here's the error: {exception.Message}");
            }
        }
        #endregion
    }
}