namespace Shared.Dtos.Person
{
    public record CreatePersonDto(string FirstName, string LastName, DateOnly DateOfBirth, string? JobTitle);
}
