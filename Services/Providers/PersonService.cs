using AutoMapper;
using Entities;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using Services.Interfaces;
using Shared.Dtos.Person;
using Shared.Dtos.Task;

namespace Services.Providers
{
    public class PersonService : IPersonService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonService> _logger;

        public PersonService(IRepositoryManager repositoryManager, IMapper mapper, ILogger<PersonService> logger)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<PersonDto>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var getPersons = await _repositoryManager.PersonRepository.GetAllAsync(cancellationToken);
                var getPersonsOut = _mapper.Map<List<PersonDto>>(getPersons);
                return getPersonsOut;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
                
            }

            return [];
        }

        public async Task<PersonDto?> GetById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var uniquePerson = await _repositoryManager.PersonRepository.GetUniqueAsync(id, cancellationToken);
                var uniquePersonOut = _mapper.Map<PersonDto>(uniquePerson);
                return uniquePersonOut;
            }
            catch (Exception ex)
            {

                _logger.LogDebug(ex.Message);
            }
            return null;
        }

        public async Task<bool> Update(Guid Id, UpdatePersonDto person, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.PersonRepository.GetUniqueAsync(Id, cancellationToken);
            var entityDto = _mapper.Map(person, entity);
            try
            {
                var updatePerson = await _repositoryManager.PersonRepository.UpdatePersonAsync(entityDto, cancellationToken);
                _repositoryManager.Save();
                return updatePerson;
            }
            catch (Exception ex)
            {
               _logger.LogDebug(ex.Message);
            }
            return false;
        }

        public async Task<bool> Create(CreatePersonDto person, CancellationToken cancellationToken)
        {
            //convert to entity
            var entity = _mapper.Map<Person>(person);
            try
            {
                var createEntity = await _repositoryManager.PersonRepository.CreatePersonAsync(entity, cancellationToken);
                _repositoryManager.Save();
                return true;
            }
            catch (Exception ex)
            {

               _logger.LogDebug(ex.Message);
            }
            return false;
        }

        public async Task<bool> Delete(Guid Id, CancellationToken cancellationToken)
        {
            try
            {
                var deleteEntity = await _repositoryManager.PersonRepository.DeleteAsync(Id, cancellationToken);
                _repositoryManager.Save();
                return deleteEntity;
            }
            catch (Exception ex)
            {

               _logger.LogDebug(ex.Message);
            }
            return false;
        }
    }
}
