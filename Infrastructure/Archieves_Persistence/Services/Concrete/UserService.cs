using Archieves_Application.Dtos;
using Archieves_Application.Interfaces.Repositories.Abstract;
using Archieves_Application.Interfaces.Services.Abstract;
using Archieves_Application.Parameters.Common;
using Archieves_Application.Wrappers;
using Archieves_Domain.Entities;
using AutoMapper;

namespace Archieves_Persistence.Services.Concrete
{
    public class UserService : IUserService
    {
        #region Properties
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion
        #region Methods
        public async Task<ModelResponse<UserDto>> AddAsync(UserDto dto)
        {
            try
            {
                // Map dto to entity
                var entity = _mapper.Map<User>(dto);
                // Add entity to database
                var process = await _repository.AddAsync(entity);
                if (process is null)
                    // Return error response
                    return new ModelResponse<UserDto>().Fail($"Failed to add user.");
                // Map entity to dto
                var result = _mapper.Map<UserDto>(process);
                // Return success response
                return new ModelResponse<UserDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<UserDto>().Fail($"Failed to add user: {exception.Message}");
            }
        }

        public async Task<ModelResponse<UserDto>> UpdateAsync(UserDto dto)
        {
            try
            {
                // Map dto to entity
                var entity = _mapper.Map<User>(dto);
                // Update entity in database
                var process = await _repository.UpdateAsync(entity);
                if (process is null)
                    // Return error response
                    return new ModelResponse<UserDto>().Fail($"Failed to update user.");
                // Map entity to dto
                var result = _mapper.Map<UserDto>(process);
                // Return success response
                return new ModelResponse<UserDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<UserDto>().Fail($"Failed to update user: {exception.Message}");
            }
        }

        public async Task<ModelResponse<UserDto>> DeleteAsync(UserDto dto)
        {
            try
            {
                // Map dto to entity
                var entity = _mapper.Map<User>(dto);
                // Delete entity from database
                var process = await _repository.DeleteAsync(entity);
                if (!process)
                    // Return error response
                    return new ModelResponse<UserDto>().Fail($"Failed to delete user.");
                // Map entity to dto
                var result = _mapper.Map<UserDto>(entity);
                // Return success response
                return new ModelResponse<UserDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<UserDto>().Fail($"Failed to delete user: {exception.Message}");
            }
        }

        public async Task<ModelResponse<UserDto>> DeleteAsync(int id)
        {
            try
            {
                // Get entity from database
                var entity = await _repository.GetByIdAsync(id);
                if (entity is null)
                    // Return error response
                    return new ModelResponse<UserDto>().Fail($"User not found.");
                // Delete entity from database
                var process = await _repository.DeleteAsync(entity);
                if (!process)
                    // Return error response
                    return new ModelResponse<UserDto>().Fail($"Failed to delete user.");
                // Map entity to dto
                var result = _mapper.Map<UserDto>(entity);
                // Return success response
                return new ModelResponse<UserDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<UserDto>().Fail($"Failed to delete user: {exception.Message}");
            }
        }

        public async Task<ModelResponse<UserDto>> GetByIdAsync(int id)
        {
            try
            {
                // Get entity from database
                var entity = await _repository.GetByIdAsync(id);
                if (entity is null)
                    // Return error response
                    return new ModelResponse<UserDto>().Fail($"User not found.");
                // Map entity to dto
                var result = _mapper.Map<UserDto>(entity);
                // Return success response
                return new ModelResponse<UserDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<UserDto>().Fail($"Failed to get user: {exception.Message}");
            }
        }

        public async Task<PagedModelResponse<List<UserDto>>> GetAllAsync(ArchievesListRequestParameter parameter)
        {
            try
            {
                // Get entities from database
                var entities = await _repository.GetAllAsync();
                if (entities is null)
                    // Return error response
                    return new PagedModelResponse<List<UserDto>>().Fail($"Failed to get users.");
                // Map entities to dtos
                var dtos = _mapper.Map<List<UserDto>>(entities);
                // Return success response
                return new PagedModelResponse<List<UserDto>>().Success(dtos, (int)parameter.PageNumber, (int)parameter.PageSize, (int)(dtos.Count / parameter.PageSize) + 1, dtos.Count);
            }
            catch (Exception exception)
            {
                // Log exception
                return new PagedModelResponse<List<UserDto>>().Fail($"Failed to get users: {exception.Message}");
            }
        }
        #endregion
    }
}