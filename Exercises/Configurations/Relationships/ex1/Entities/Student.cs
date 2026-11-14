namespace EfPractice.Exercises.Configurations.Relationships.ex1.Entities;

public class Student
{
    private const int NameMaxLength = 100;

    private readonly List<Course> _courses = [];

    public Student(string fullName)
    {
        Validate(fullName);

        FullName = fullName;
    }
    
    public int Id { get; private set; }
    public string FullName { get; private set; } = string.Empty;
    public IReadOnlyCollection<Course> Courses => _courses.AsReadOnly();

    public void AddCourse(Course course)
    {
        if (_courses.Any(c => c.Id == course.Id))
        {
            throw new InvalidOperationException(
                "This course has already been added.");
        }

        _courses.Add(course);
    }

    public void RemoveCourse(Course course)
    {
        if (!_courses.Any(c => c.Id == course.Id))
        {
            throw new InvalidOperationException(
                "This course does not exist.");
        }

        _courses.Remove(course);
    }

    private static void Validate(string fullName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fullName);
        if (fullName.Length > NameMaxLength)
        {
            throw new ArgumentOutOfRangeException(
                nameof(fullName), 
                $"Maximum length is {NameMaxLength} characters.");
        }
    }

    private Student() { }
}
