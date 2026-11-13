using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfPractice.Exercises.Configurations.FluentApi.ex2;

public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("products", "public", t =>
        {   
            t.HasCheckConstraint("ck_product_stock_quantity", "stock_quantity >= 0");
            t.HasCheckConstraint("ck_product_price", "price >= 0");
        });

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)            
            .HasColumnName("id")
            .UseIdentityAlwaysColumn();

        builder.Property(p => p.Sku)
            .HasColumnName("sku")
            .HasMaxLength(32)
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
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(p => p.StockQuantity)
            .HasColumnName("stock_quantity")
            .HasDefaultValue(0);

        builder.Property(p => p.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true);

        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("now()");

        builder.HasIndex(p => p.Sku)
            .IsUnique()
            .HasDatabaseName("ix_product_sku");

        builder.HasIndex(p => p.Name)
            .HasDatabaseName("ix_product_name");
    }        
}
