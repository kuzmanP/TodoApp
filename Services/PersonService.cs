using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities;
using Services.Contracts;
using Shared.Dtos.Person;

namespace Services
{
    public class PersonService:IPersonService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public PersonService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<List<PersonDto>> GetAllPerson(CancellationToken cancellationToken)
        {
            var getPersons =await _repositoryManager.PersonRepository.GetAllPersonsAsync(cancellationToken);
            var getPersonsOut = _mapper.Map<List<PersonDto>>(getPersons);
            return getPersonsOut;
        }

        public async Task<PersonDto> GetPersonById(Guid id, CancellationToken cancellationToken)
        {
            var uniquePerson =await _repositoryManager.PersonRepository.GetUniquePersonAsync(id, cancellationToken);
            var uniquePersonOut = _mapper.Map<PersonDto>(uniquePerson);
            return uniquePersonOut;
        }

        public async Task<bool> UpdatePerson(Guid Id, UpdatePersonDto person, CancellationToken cancellationToken)
        {
            var entity =await _repositoryManager.PersonRepository.GetUniquePersonAsync(Id, cancellationToken);
            var entityDto = _mapper.Map(person, entity);
            try
            {
                var updatePerson =await _repositoryManager.PersonRepository.UpdatePersonAsync(entityDto, cancellationToken);
                _repositoryManager.Save();
                return updatePerson;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public async Task<bool> CreatePerson(CreatePersonDto person, CancellationToken cancellationToken)
        {
            //convert to entity
            var entity = _mapper.Map<Person>(person);
            var createEntity =await _repositoryManager.PersonRepository.CreatePersonAsync(entity, cancellationToken);
            _repositoryManager.Save();
            return true;
        }

        public async Task<bool> DeletePerson(Guid Id, CancellationToken cancellationToken)
        {
            var deleteEntity =await _repositoryManager.PersonRepository.DeletePersonAsync(Id, cancellationToken);
            _repositoryManager.Save();
            return true;
        }
    }
}
