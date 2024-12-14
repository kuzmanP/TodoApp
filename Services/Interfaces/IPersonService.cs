using Shared.Dtos.Person;

namespace Services.Interfaces
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
