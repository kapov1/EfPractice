using EfPractice;
using EfPractice.OnlineStore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = 
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Database connection string 'DefaultConnection' is not configured.");

builder.Services.AddDbContext<OnlineStoreDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

var app = builder.Build();

app.MapGet("/example", async (OnlineStoreDbContext context) => 
{
    QueryPractice practice = new(context);

    await practice.Example();
});

app.Run();