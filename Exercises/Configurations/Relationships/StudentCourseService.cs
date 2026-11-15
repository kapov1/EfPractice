using EfPractice.Exercises.Configurations.Relationships.ex1.Entities;

namespace EfPractice.Exercises.Configurations.Relationships;

public class StudentCourseService
{
    public void AddStudentToCourseorThrow(Student student, Course course)
    {
        course.AddStudent(student);
        student.AddCourse(course);
    }

    public void RemoveStudentFromCourseOrThrow(Student student, Course course)
    {
        course.RemoveStudent(student);
        student.RemoveCourse(course);
    }
}
