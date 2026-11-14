using EfPractice.Exercises.Configurations.Relationships.ex1.Entities;

namespace EfPractice.Exercises.Configurations.Relationships.ex1.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("students", "public");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .HasColumnName("student_id")
            .UseIdentityAlwaysColumn();

        builder.Property(u => u.FullName)
            .HasColumnName("full_name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Courses)
            .HasColumnName("student_courses");
    }
}
