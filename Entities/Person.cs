namespace Entities
{
    public class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public string? JobTitle { get; set; }
        public ICollection<Tasks>? Task { get; set; }

    }
}
