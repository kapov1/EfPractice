using EfPractice.Exercises.Configurations.Relationships.ex1.Entities;

namespace EfPractice.Exercises.Configurations.Relationships.ex1.Configurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.ToTable("instructors", "public");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasColumnName("instructor_id")
            .UseIdentityAlwaysColumn();

        builder.Property(i => i.Name)
            .HasColumnName("instructor_name")
            .HasMaxLength(100)
            .IsRequired();
    }
}
