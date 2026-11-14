namespace EfPractice.Exercises.Configurations.ForeignKey.ex1.Entities;

public class Author
{
    public Author(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Name = name;
    }

    public int AuthorId { get; private set; }

    public string Name { get; private set; } = string.Empty;
}
