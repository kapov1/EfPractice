using EfPractice.Exercises.Configurations.ex1FluentApi;

namespace EfPractice;

public class AppDbContext(
    DbContextOptions options)
    : DbContext(options)
{
    public DbSet<NotebookEntity> Notebooks => Set<NotebookEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly);
    }
}
