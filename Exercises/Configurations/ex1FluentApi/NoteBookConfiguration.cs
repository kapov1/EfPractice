using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfPractice.Exercises.Configurations.ex1FluentApi;

public class NoteBookConfiguration : IEntityTypeConfiguration<NotebookEntity>
{
    public void Configure(EntityTypeBuilder<NotebookEntity> builder)
    {
        builder.ToTable("notebooks", "public");

        builder.HasKey(n => n.Id);

        builder.Property(n => n.Id)
            .UseIdentityAlwaysColumn()
            .HasColumnName("id");

        builder.Property(n => n.Name)
            .HasMaxLength(80)
            .IsRequired()
            .HasColumnName("name");

        builder.Property(n => n.Description)
            .HasMaxLength(300)
            .HasDefaultValue(null)
            .HasColumnName("description");

        builder.Property(n => n.CreatedAt)
            .HasColumnName("created_at");
    }
}
