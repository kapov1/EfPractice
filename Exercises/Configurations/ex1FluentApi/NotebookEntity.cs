namespace EfPractice.Exercises.Configurations.ex1FluentApi;

public class NotebookEntity
{
    public int Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;
}
