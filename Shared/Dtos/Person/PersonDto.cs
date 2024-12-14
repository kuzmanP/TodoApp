namespace Shared.Dtos.Person
{
    public  record PersonDto(string FirstName, string LastName, DateOnly DateOfBirth, string? JobTitle);

}
