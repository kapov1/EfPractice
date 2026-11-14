using EfPractice.Exercises.Configurations.KeyConfiguration.ex1.Entities;
using EfPractice.Exercises.Configurations.Relationships.ex1.Entities;

namespace EfPractice.Exercises.Configurations.Relationships.ex1.Configurations;

public class StudentProfilesConfiguration : IEntityTypeConfiguration<StudentProfile>
{
    public void Configure(EntityTypeBuilder<StudentProfile> builder)
    {
        builder.HasKey(sp => sp.Id);

        builder.Property(sp => sp.Id)
            .HasColumnName("profile_id")
            .UseIdentityAlwaysColumn();

        builder.Property(sp => sp.StudentId)
            .HasColumnName("student_id")
            .IsRequired();

        builder.Property(sp => sp.Bio)
            .HasColumnName("bio")
            .HasMaxLength(1000);

        builder.HasOne<User>()
            .WithOne()
            .HasForeignKey<StudentProfile>(sp => sp.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
