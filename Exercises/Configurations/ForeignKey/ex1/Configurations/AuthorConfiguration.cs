using EfPractice.Exercises.Configurations.ForeignKey.ex1.Entities;

namespace EfPractice.Exercises.Configurations.ForeignKey.ex1.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("rel_authors", "public");

        builder.HasKey(a => a.AuthorId);

        builder.Property(a => a.AuthorId)
            .HasColumnName("author_id")
            .UseIdentityAlwaysColumn();

        builder.Property(a => a.Name)
            .HasColumnName("author_name")
            .IsRequired();
    }
}
