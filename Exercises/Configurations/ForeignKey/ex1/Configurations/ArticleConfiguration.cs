using EfPractice.Exercises.Configurations.ForeignKey.ex1.Entities;

namespace EfPractice.Exercises.Configurations.ForeignKey.ex1.Configurations;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("rel_articles", "public");

        builder.HasKey(a => a.ArticleId);

        builder.Property(a => a.ArticleId)
            .HasColumnName("article_id")
            .UseIdentityAlwaysColumn();

        builder.Property(a => a.AuthorId)
            .HasColumnName("author_id");

        builder.Property(a => a.Title)
            .HasColumnName("article_title")
            .IsRequired();

        builder.HasOne<Author>()
            .WithMany()
            .HasForeignKey(a => a.AuthorId);
    }
}
