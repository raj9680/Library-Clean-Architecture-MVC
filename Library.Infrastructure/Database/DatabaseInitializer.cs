using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Database;

public static class DatabaseInitializer
{
    public static async Task InitializeAsync(
        DatabaseContext dbContext,
        bool runMigrations,
        bool runSqlScripts)
    {
        // Apply pending migrations
        if (runMigrations)
        {
            await dbContext.Database.MigrateAsync();
        }

        // Execute SQL scripts
        if (runSqlScripts)
        {
            await ExecuteScriptsAsync(dbContext, "StoredProcedures");
            await ExecuteScriptsAsync(dbContext, "Views");
            await ExecuteScriptsAsync(dbContext, "Functions");
            await ExecuteScriptsAsync(dbContext, "Seed");
        }
    }

    private static async Task ExecuteScriptsAsync(
        DatabaseContext dbContext,
        string folderName)
    {
        string folderPath = Path.Combine(
            AppContext.BaseDirectory,
            "Database", folderName);

        if (!Directory.Exists(folderPath))
            return;

        // it execute in order i.e 01_CreateCountry.sql, 02_CreatePerson.sql
        var sqlFiles = Directory.GetFiles(folderPath, "*.sql") 
            .OrderBy(file => file); 

        foreach (var file in sqlFiles)
        {
            var sql = await File.ReadAllTextAsync(file);

            if (!string.IsNullOrWhiteSpace(sql))
            {
                await dbContext.Database.ExecuteSqlRawAsync(sql);
            }
        }
    }
}