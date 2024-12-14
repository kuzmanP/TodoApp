using AutoMapper;
using Entities;
using Repository.Interfaces;
using Services.Interfaces;
using Shared.Dtos.Person;

namespace Services.Providers
{
    public class PersonService : IPersonService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public PersonService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<List<PersonDto>> GetAll(CancellationToken cancellationToken)
        {
            var getPersons = await _repositoryManager.PersonRepository.GetAllAsync(cancellationToken);
            var getPersonsOut = _mapper.Map<List<PersonDto>>(getPersons);
            return getPersonsOut;
        }

        public async Task<PersonDto> GetById(Guid id, CancellationToken cancellationToken)
        {
            var uniquePerson = await _repositoryManager.PersonRepository.GetUniqueAsync(id, cancellationToken);
            var uniquePersonOut = _mapper.Map<PersonDto>(uniquePerson);
            return uniquePersonOut;
        }

        public async Task<bool> Update(Guid Id, UpdatePersonDto person, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.PersonRepository.GetUniqueAsync(Id, cancellationToken);
            var entityDto = _mapper.Map(person, entity);
            try
            {
                var updatePerson = await _repositoryManager.PersonRepository.UpdateAsync(entityDto, cancellationToken);
                _repositoryManager.Save();
                return updatePerson;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public async Task<bool> Create(CreatePersonDto person, CancellationToken cancellationToken)
        {
            //convert to entity
            var entity = _mapper.Map<Person>(person);
            var createEntity = await _repositoryManager.PersonRepository.CreateAsync(entity, cancellationToken);
            _repositoryManager.Save();
            return true;
        }

        public async Task<bool> Delete(Guid Id, CancellationToken cancellationToken)
        {
            var deleteEntity = await _repositoryManager.PersonRepository.DeleteAsync(Id, cancellationToken);
            _repositoryManager.Save();
            return true;
        }
    }
}
