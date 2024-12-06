using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Dtos.Person;

namespace Services.Contracts
{
    public interface IPersonService
    {
        Task<List<PersonDto>> GetAllPerson(CancellationToken cancellationToken);
        Task<PersonDto> GetPersonById(Guid id, CancellationToken cancellationToken);
        Task<bool> UpdatePerson(Guid Id, UpdatePersonDto person, CancellationToken cancellationToken);
        Task<bool> CreatePerson(CreatePersonDto person, CancellationToken cancellationToken);
        Task<bool> DeletePerson(Guid Id, CancellationToken cancellationToken);
    }
}
