using EfPractice.Exercises.Configurations.KeyConfiguration.ex1.Entities;

namespace EfPractice.Exercises.Configurations.KeyConfiguration.ex1.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products", "public");

        builder.HasKey(p => p.Id);

        builder.HasAlternateKey(p => p.Sku);

        builder.Property(p => p.Id)
            .HasColumnName("product_id")
            .UseIdentityAlwaysColumn();

        builder.Property(p => p.Sku)
            .HasColumnName("sku");

        builder.Property(p => p.Name)
            .HasColumnName("product_name")
            .IsRequired();
    }
}
