using Archieves_Application.Dtos;
using Archieves_Application.Interfaces.Repositories.Abstract;
using Archieves_Application.Interfaces.Services.Abstract;
using Archieves_Application.Parameters.Common;
using Archieves_Application.Wrappers;
using Archieves_Domain.Entities;
using AutoMapper;

namespace Archieves_Persistence.Services.Concrete
{
    public class PersonService : IPersonService
    {
        #region Properties
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public PersonService(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion
        #region Methods
        public async Task<ModelResponse<PersonDto>> AddAsync(PersonDto dto)
        {
            try
            {
                // Map dto to entity
                var entity = _mapper.Map<Person>(dto);
                // Add entity to database
                var process = await _repository.AddAsync(entity);
                if (process is null)
                    // Return error response
                    return new ModelResponse<PersonDto>().Fail("An error occurred when saving the person");
                // Map entity to dto
                var result = _mapper.Map<PersonDto>(process);
                // Return success response
                return new ModelResponse<PersonDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<PersonDto>().Fail($"An error occurred when saving the person: {exception.Message}");
            }
        }

        public async Task<ModelResponse<PersonDto>> UpdateAsync(PersonDto dto)
        {
            try
            {
                // Map dto to entity
                var entity = _mapper.Map<Person>(dto);
                // Update entity in database
                var process = await _repository.UpdateAsync(entity);
                if (process is null)
                    // Return error response
                    return new ModelResponse<PersonDto>().Fail("An error occurred when updating the person");
                // Map entity to dto
                var result = _mapper.Map<PersonDto>(process);
                // Return success response
                return new ModelResponse<PersonDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<PersonDto>().Fail($"An error occurred when updating the person: {exception.Message}");
            }
        }

        public async Task<ModelResponse<PersonDto>> DeleteAsync(PersonDto dto)
        {
            try
            {
                // Map the dto to the entity
                var entity = _mapper.Map<Person>(dto);
                // Delete entity from database
                var process = await _repository.DeleteAsync(entity);
                if (!process)
                    // Return error response
                    return new ModelResponse<PersonDto>().Fail("An error occurred when deleting the person");
                // Map entity to dto
                var result = _mapper.Map<PersonDto>(process);
                // Return success response
                return new ModelResponse<PersonDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<PersonDto>().Fail($"An error occurred when deleting the person: {exception.Message}");
            }
        }

        public async Task<ModelResponse<PersonDto>> DeleteAsync(int id)
        {
            try
            {
                // Get entity by id
                var entity = await _repository.GetByIdAsync(id);
                if (entity is null)
                    // Return error response
                    return new ModelResponse<PersonDto>().Fail("Person not found");
                // Delete entity from database
                var process = await _repository.DeleteAsync(entity);
                if (!process)
                    // Return error response
                    return new ModelResponse<PersonDto>().Fail("An error occurred when deleting the person");
                // Map entity to dto
                var result = _mapper.Map<PersonDto>(process);
                // Return success response
                return new ModelResponse<PersonDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<PersonDto>().Fail($"An error occurred when deleting the person: {exception.Message}");
            }
        }

        public async Task<ModelResponse<PersonDto>> GetByIdAsync(int id)
        {
            try
            {
                // Get entity by id
                var entity = await _repository.GetByIdAsync(id);
                if (entity is null)
                    // Return error response
                    return new ModelResponse<PersonDto>().Fail("Person not found");
                // Map entity to dto
                var result = _mapper.Map<PersonDto>(entity);
                // Return success response
                return new ModelResponse<PersonDto>().Success(result);
            }
            catch (Exception exception)
            {
                // Log exception
                return new ModelResponse<PersonDto>().Fail($"An error occurred when getting the person: {exception.Message}");
            }
        }

        public async Task<PagedModelResponse<List<PersonDto>>> GetAllAsync(ArchievesListRequestParameter parameter)
        {
            try
            {
                // Get entities from database
                var entities = await _repository.GetAllAsync();
                if (entities is null)
                    // Return error response
                    return new PagedModelResponse<List<PersonDto>>().Fail("An error occurred when getting the people");
                // Map entities to dtos
                var dtos = _mapper.Map<List<PersonDto>>(entities);
                // Return success response
                return new PagedModelResponse<List<PersonDto>>().Success(dtos, (int)parameter.PageNumber, (int)parameter.PageSize, (int)(dtos.Count / parameter.PageSize) + 1, dtos.Count);
            }
            catch (Exception exception)
            {
                // Log exception
                return new PagedModelResponse<List<PersonDto>>().Fail($"An error occurred when getting the people: {exception.Message}");
            }
        }
        #endregion
    }
}