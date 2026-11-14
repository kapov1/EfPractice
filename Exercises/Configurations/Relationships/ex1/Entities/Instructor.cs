namespace EfPractice.Exercises.Configurations.Relationships.ex1.Entities;

public class Instructor
{
    private const int NameMaxLength = 100;

    public Instructor(string name)
    {
        Validate(name);

        Name = name;
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    private static void Validate(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(
            name, 
            nameof(name));

        if (name.Length > NameMaxLength)
        {
            throw new ArgumentOutOfRangeException(
                nameof(name), 
                $"Maximum length is {NameMaxLength} characters.");
        }
    }

    private Instructor() { }
}
