using Shared.Dtos.Person;

namespace Services.Interfaces
{
    public interface IPersonService
    {
        Task<List<PersonDto>> GetAll(CancellationToken cancellationToken);
        Task<PersonDto?> GetById(Guid id, CancellationToken cancellationToken);
        Task<bool> Update(Guid Id, UpdatePersonDto person, CancellationToken cancellationToken);
        Task<bool> Create(CreatePersonDto person, CancellationToken cancellationToken);
        Task<bool> Delete(Guid Id, CancellationToken cancellationToken);
    }
}
