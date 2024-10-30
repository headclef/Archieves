using Archieves_Application.Dtos;
using Archieves_Application.Interfaces.Repositories.Abstract;
using Archieves_Application.Interfaces.Services.Abstract;
using Archieves_Application.Parameters.Common;
using Archieves_Application.Wrappers;
using Archieves_Domain.Entities;
using AutoMapper;

namespace Archieves_Persistence.Services.Concrete
{
    public class PublisherService : IPublisherService
    {
        #region Properties
        private readonly IPublisherRepository _repository;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public PublisherService(IPublisherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion
        #region Methods
        public async Task<ModelResponse<PublisherDto>> AddAsync(PublisherDto dto)
        {
            try
            {
                // Map the dto to the entity
                var entity = _mapper.Map<Publisher>(dto);
                // Add the entity to database
                var process = await _repository.AddAsync(entity);
                if (process is null)
                    // Return the response
                    return new ModelResponse<PublisherDto>().Fail($"Failed to add publisher: {process}");
                // Map the entity to the dto
                var response = _mapper.Map<PublisherDto>(process);
                // Return the response
                return new ModelResponse<PublisherDto>().Success(response);
            }
            catch (Exception exception)
            {
                // Log the exception
                return new ModelResponse<PublisherDto>().Fail($"Failed to add publisher: {exception.Message}");
            }
        }

        public async Task<ModelResponse<PublisherDto>> UpdateAsync(PublisherDto dto)
        {
            try
            {
                // Map the dto to the entity
                var entity = _mapper.Map<Publisher>(dto);
                // Update the entity to database
                var process = await _repository.UpdateAsync(entity);
                if (process is null)
                    // Return the response
                    return new ModelResponse<PublisherDto>().Fail($"Failed to update publisher: {process}");
                // Map the entity to the dto
                var response = _mapper.Map<PublisherDto>(process);
                // Return the response
                return new ModelResponse<PublisherDto>().Success(response);
            }
            catch (Exception exception)
            {
                // Log the exception
                return new ModelResponse<PublisherDto>().Fail($"Failed to update publisher: {exception.Message}");
            }
        }

        public async Task<ModelResponse<PublisherDto>> DeleteAsync(PublisherDto dto)
        {
            try
            {
                // Map the dto to the entity
                var entity = _mapper.Map<Publisher>(dto);
                // Delete the entity from database
                var process = await _repository.DeleteAsync(entity);
                if (!process)
                    // Return the response
                    return new ModelResponse<PublisherDto>().Fail($"Failed to delete publisher: {process}");
                // Map the entity to the dto
                var response = _mapper.Map<PublisherDto>(process);
                // Return the response
                return new ModelResponse<PublisherDto>().Success(response);
            }
            catch (Exception exception)
            {
                // Log the exception
                return new ModelResponse<PublisherDto>().Fail($"Failed to delete publisher: {exception.Message}");
            }
        }

        public async Task<ModelResponse<PublisherDto>> DeleteAsync(int id)
        {
            try
            {
                // Get entity by id
                var entity = await _repository.GetByIdAsync(id);
                if (entity is null)
                    // Return the response
                    return new ModelResponse<PublisherDto>().Fail("Publisher not found");
                // Delete the entity from database
                var process = await _repository.DeleteAsync(entity);
                if (!process)
                    // Return the response
                    return new ModelResponse<PublisherDto>().Fail($"Failed to delete publisher: {process}");
                // Map the entity to the dto
                var response = _mapper.Map<PublisherDto>(process);
                // Return the response
                return new ModelResponse<PublisherDto>().Success(response);
            }
            catch (Exception exception)
            {
                // Log the exception
                return new ModelResponse<PublisherDto>().Fail($"Failed to delete publisher: {exception.Message}");
            }
        }

        public async Task<ModelResponse<PublisherDto>> GetByIdAsync(int id)
        {
            try
            {
                // Get entity by id
                var entity = await _repository.GetByIdAsync(id);
                if (entity is null)
                    // Return the response
                    return new ModelResponse<PublisherDto>().Fail("Publisher not found");
                // Map the entity to the dto
                var response = _mapper.Map<PublisherDto>(entity);
                // Return the response
                return new ModelResponse<PublisherDto>().Success(response);
            }
            catch (Exception exception)
            {
                // Log the exception
                return new ModelResponse<PublisherDto>().Fail($"Failed to get publisher: {exception.Message}");
            }
        }

        public async Task<PagedModelResponse<List<PublisherDto>>> GetAllAsync(ArchievesListRequestParameter parameter)
        {
            try
            {
                // Get all entities
                var entities = await _repository.GetAllAsync();
                if (entities is null)
                    // Return the response
                    return new PagedModelResponse<List<PublisherDto>>().Fail("Publishers not found");
                // Map the entities to the dtos
                var dtos = _mapper.Map<List<PublisherDto>>(entities);
                // Return the response
                return new PagedModelResponse<List<PublisherDto>>().Success(dtos, (int)parameter.PageNumber, (int)parameter.PageSize, (int)(dtos.Count / parameter.PageSize) + 1, dtos.Count);
            }
            catch (Exception exception)
            {
                // Log the exception
                return new PagedModelResponse<List<PublisherDto>>().Fail($"Failed to get publishers: {exception.Message}");
            }
        }
        #endregion
    }
}