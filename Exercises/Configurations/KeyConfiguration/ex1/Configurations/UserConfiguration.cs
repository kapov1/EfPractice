using EfPractice.Exercises.Configurations.KeyConfiguration.ex1.Entities;

namespace EfPractice.Exercises.Configurations.KeyConfiguration.ex1.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users", "public");

        builder.HasKey(u => u.Id);

        builder.HasAlternateKey(u => u.Email);

        builder.Property(u => u.Id)
            .HasColumnName("user_id");

        builder.Property(u => u.Email)
            .HasColumnName("user_email");

        builder.Property(u => u.Name)
            .HasColumnName("user_name")
            .IsRequired();
    }
}
