namespace Shared.Dtos.Person
{
    public record UpdatePersonDto(string FirstName, string LastName, DateOnly DateOfBirth, string? JobTitle);

}
