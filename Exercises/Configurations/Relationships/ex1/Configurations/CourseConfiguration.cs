using EfPractice.Exercises.Configurations.Relationships.ex1.Entities;

namespace EfPractice.Exercises.Configurations.Relationships.ex1.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("courses", "public");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("course_id")
            .UseIdentityAlwaysColumn();

        builder.Property(c => c.Title)
            .HasColumnName("course_title")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(c => c.InstructorId)
            .HasColumnName("instructor_id")
            .IsRequired();

        builder.HasOne(c => c.Instructor)
            .WithMany()
            .HasForeignKey(c => c.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Students)
            .WithMany(s => s.Courses)
            .UsingEntity("course_student");
    }
}
