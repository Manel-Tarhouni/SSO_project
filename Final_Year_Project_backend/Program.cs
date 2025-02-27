using AM.ApplicationCore;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//await app.MigrateDatabase<DbContext>();
//await app.RunAsync();
var builder = WebApplication.CreateBuilder(args);
// Register the DbContext (AMContext) with the DI container
builder.Services.AddDbContext<AMContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"))); 
// Swagger setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container BEFORE calling Build().
builder.Services.AddControllers();




// Add ASP.NET Core Identity services
builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<AMContext>()
    .AddDefaultTokenProviders();

// Optionally, configure identity options (e.g., password complexity, lockout settings)
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
});
builder.Services.AddScoped<ICustomPasswordHasher, CustomPasswordHasher>();

builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<IUserService<User>,UserService>();  

var app = builder.Build();

 // Now we can call Build() after all services are registered.


// Apply any pending migrations and create the database if needed
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AMContext>();
    //    dbContext.Database.Migrate(); // This applies any pending migrations
    await dbContext.Database.MigrateAsync(); // Migration asynchrone

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
