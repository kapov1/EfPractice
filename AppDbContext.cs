using Microsoft.EntityFrameworkCore;
using EfPractice.Exercises.Configurations.FluentApi.ex1;
using EfPractice.Exercises.Configurations.FluentApi.ex2;
using EfPractice.Exercises.Configurations.KeyConfiguration.ex1.Entities;


namespace EfPractice;

public class AppDbContext(
    DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<NotebookEntity> Notebooks => Set<NotebookEntity>();

    public DbSet<ProductEntity> ProductEntities => Set<ProductEntity>();

    public DbSet<GroupMembership> GroupMemberships => Set<GroupMembership>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly);
    }
}
