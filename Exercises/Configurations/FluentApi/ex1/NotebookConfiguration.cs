namespace EfPractice.Exercises.Configurations.FluentApi.ex1;

public class NotebookConfiguration : IEntityTypeConfiguration<NotebookEntity>
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
            .HasColumnName("notebook_name");

        builder.Property(n => n.Description)
            .HasMaxLength(300)
            .HasColumnName("description");

        builder.Property(n => n.CreatedAt)
            .HasColumnName("created_at");
    }
}
