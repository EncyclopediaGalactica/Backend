using EncyclopediaGalactica.Core.Application;
using EncyclopediaGalactica.Core.Infrastructure.Database;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

SqliteConnection connection = new("Filename=:memory:");
connection.Open();
DbContextOptions<DocumentDomainDbContext> dbContextOptions = new DbContextOptionsBuilder<DocumentDomainDbContext>()
                                                             .UseSqlite(connection)
                                                             .EnableSensitiveDataLogging()
                                                             .EnableDetailedErrors()
                                                             .Options;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services
       .AddDbContext<DocumentDomainDbContext>(o =>
       {
           o.UseSqlite(connection);
           using DocumentDomainDbContext ctx = new(dbContextOptions);
           ctx.Database.EnsureDeleted();
           ctx.Database.EnsureCreated();
       })
       .AddScoped<AddApplicationScenario>()
       .AddScoped<AddApplicationScenarioInputValidator>()
    ;

WebApplication app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.Run();