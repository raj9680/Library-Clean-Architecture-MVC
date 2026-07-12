using Library.Infrastructure.Data;
using Library.Infrastructure.Database;
using Library.UI;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// All DI's
builder.Services.AddDI(builder.Configuration);



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

#region Database Initializer
// DB Initialiser
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

    bool runMigrations = builder.Configuration.GetValue<bool>("DatabaseSettings:RunMigrations");
    bool runSqlScripts = builder.Configuration.GetValue<bool>("DatabaseSettings:RunSqlScripts");

    await DatabaseInitializer.InitializeAsync(
        dbContext,
        runMigrations,
        runSqlScripts);
}
#endregion


app.Run();
