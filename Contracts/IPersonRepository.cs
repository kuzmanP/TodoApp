using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPersonsAsync(CancellationToken cancellation);
        Task<bool> DeletePersonAsync(Guid Id, CancellationToken cancellation);
        Task<Person> GetUniquePersonAsync(Guid Id, CancellationToken cancellation);
        Task<bool> CreatePersonAsync(Person person, CancellationToken cancellation);
        Task<bool> UpdatePersonAsync(Person person, CancellationToken cancellation);
    }
}
