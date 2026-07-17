using Library.Infrastructure.Common;
using Library.Infrastructure.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data;

public static class DatabaseInitializer
{
    public static async Task InitializeAsync(
        LibraryDbContext dbContext,
        bool runMigrations,
        bool runSeedData,
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
            await ExecuteScriptsAsync(dbContext, "Indexes");
        }

        // Execute Seed
        if (runSeedData)
        {
            await SeedData.SeedAsync(dbContext);
        }
    }

    private static async Task ExecuteScriptsAsync(
        LibraryDbContext dbContext,
        string folderName)
    {
        string folderPath = 
            InfrastructurePath.Data("Sql", folderName);

        if (!Directory.Exists(folderPath))
            return;

        // it execute in order i.e 01_****.sql, 02_****.sql
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