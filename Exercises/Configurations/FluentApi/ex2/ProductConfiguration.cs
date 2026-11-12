namespace EfPractice.Exercises.Configurations.FluentApi.ex2;

public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("products", "public");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)            
            .HasColumnName("id")
            .UseIdentityAlwaysColumn();

        builder.Property(p => p.Sku)
            .HasColumnName("sku")
            .HasMaxLength(32)
            .UseIdentityColumn()
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnName("product_name")
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnName("description")
            .HasMaxLength(1000);

        builder.Property(p => p.Price)
            .HasColumnName("price")
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(p => p.StockQuantity)
            .HasColumnName("stock_quantity")
            .HasDefaultValue(0);

        builder.Property(p => p.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true);

        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at");

        builder.HasIndex(p => p.Sku);
    }        
}
