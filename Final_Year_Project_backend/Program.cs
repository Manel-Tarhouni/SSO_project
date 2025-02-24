using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//await app.MigrateDatabase<DbContext>();
//await app.RunAsync();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container BEFORE calling Build().
builder.Services.AddControllers();

// Register the DbContext (AMContext) with the DI container
builder.Services.AddDbContext<AMContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"))); 
// Swagger setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build(); // Now we can call Build() after all services are registered.

// Apply any pending migrations and create the database if needed
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AMContext>();
    dbContext.Database.Migrate(); // This applies any pending migrations
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers(); // Ensures your API controllers are mapped correctly

//app.Run();
await app.RunAsync();
