namespace EfPractice.Exercises.Configurations.Relationships.ex1.Entities;

public class StudentProfile
{
    private const int BioMaxLength = 1000;

    public StudentProfile(int studentId, string? bio = null)
    {
        Validate(studentId, bio);

        StudentId = studentId;
        Bio = bio;
    }

    public int Id { get; private set; }
    public int StudentId { get; private set; }
    public string? Bio { get; private set; }

    private static void Validate(int studentId, string? bio)
    {
        if (studentId <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(studentId),
                "The stident ID must be positive.");
        }
        if (bio is not null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(
                nameof(bio),
                "The bio must not be white space.");

            if (bio.Length > BioMaxLength)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(bio), 
                    $"Maximum length is {BioMaxLength} characters.");
            }
        }
    }

    private StudentProfile() { }
}
