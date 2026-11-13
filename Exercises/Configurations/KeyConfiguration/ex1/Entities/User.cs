namespace EfPractice.Exercises.Configurations.KeyConfiguration.ex1.Entities;

public class User
{
    public User(string email, string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);

        Email = email;
        Name = name;
    }

    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Email { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

    private User() { }
}
