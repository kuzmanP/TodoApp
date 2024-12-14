using Contracts;
using Entities;
using Repository.Interfaces;

namespace Repository.Providers
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public PersonRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<Person>> GetAllPersonsAsync(CancellationToken cancellation)
        {
            var allPersons = await FindAllAsync(cancellation);
            return allPersons;
        }

        public async Task<bool> DeletePersonAsync(Guid Id, CancellationToken cancellation)
        {
            var entity = GetUniquePersonAsync(Id, cancellation).Result;
            try
            {
                await DeleteAsync(entity, cancellation);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<Person> GetUniquePersonAsync(Guid Id, CancellationToken cancellation)
        {
            var singlePerson = await FindByConditionAsync(sp => sp.Id.Equals(Id), trackChanges: false, cancellationToken: cancellation);
            var singlePersonOut = singlePerson.SingleOrDefault();
            return singlePersonOut;
        }

        public async Task<bool> CreatePersonAsync(Person person, CancellationToken cancellation)
        {
            try
            {
                await CreateAsync(person, cancellation);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> UpdatePersonAsync(Person person, CancellationToken cancellation)
        {
            try
            {
                await UpdateAsync(person, cancellation);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
