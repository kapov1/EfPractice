namespace EfPractice.Exercises.Configurations.Relationships.ex1.Entities;

public class Course
{
    private const int TitleMaxLength = 150;

    private readonly List<Student> _students = [];

    public Course(string title, int instructorId)
    {
        Validate(title, instructorId);

        InstructorId = instructorId;
        Title = title;
    }

    public int Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public int InstructorId { get; private set; }
    public IReadOnlyCollection<Student> Students => _students.AsReadOnly();
    public Instructor? Instructor { get; private set; }

    public void AddStudent(Student student)
    {
        if (_students.Any(s => s.Id == student.Id))
        {
            throw new InvalidOperationException(
                "This student has already been added.");
        }

        _students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        if (!_students.Any(s => s.Id == student.Id))
        {
            throw new InvalidOperationException(
                "This student does not exist.");
        }

        _students.Remove(student);
    }

    private static void Validate(string title, int instructorId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(
            title, nameof(title));

        if (instructorId <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(instructorId), 
                "The instructor ID must be positive.");
        }
        if (title.Length > TitleMaxLength)
        {
            throw new ArgumentOutOfRangeException(
                nameof(title), 
                $"Max length is {TitleMaxLength} characters.");
        }
    }

    private Course() { }
}
