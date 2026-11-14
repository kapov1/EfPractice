namespace EfPractice.Exercises.Configurations.ForeignKey.ex1.Entities;

public class Article
{
    public Article(string title, int authorId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        if (authorId <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(authorId), 
                "The author ID must be positive.");
        }

        Title = title;
        AuthorId = authorId;
    }

    public int ArticleId { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public int AuthorId { get; private set; }
}
