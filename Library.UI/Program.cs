using Library.Infrastructure.Data;
using Library.UI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDI(builder.Configuration); // All DI Regs.

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

#region Database Initializer

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();

    bool runMigrations = builder.Configuration.GetValue<bool>("DatabaseSettings:RunMigrations");
    bool runSeedData = builder.Configuration.GetValue<bool>("DatabaseSettings:RunSeedData");
    bool runSqlScripts = builder.Configuration.GetValue<bool>("DatabaseSettings:RunSqlScripts");

    await DatabaseInitializer.InitializeAsync(
        dbContext,
        runMigrations,
        runSeedData,
        runSqlScripts);
}

#endregion

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
