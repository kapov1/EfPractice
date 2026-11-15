namespace EfPractice.OnlineStore;

public class OnlineStoreDbContext(
    DbContextOptions<OnlineStoreDbContext> options)
    : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(OnlineStoreDbContext).Assembly);
    }
}
