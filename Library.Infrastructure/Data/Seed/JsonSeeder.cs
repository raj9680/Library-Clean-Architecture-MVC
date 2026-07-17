using Library.Infrastructure.Common;
using System.Text.Json;

namespace Library.Infrastructure.Data.Seed
{
    public static class JsonSeeder
    {
        public static async Task<List<T>> ReadAsync<T>(string fileName)
        {
            string filePath = InfrastructurePath.Data(
                                "Seed", $"{fileName}.json");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(
                    $"Seed file '{fileName}.json' not found.",
                    filePath);
            }

            string json = await File.ReadAllTextAsync(filePath);

            return JsonSerializer.Deserialize<List<T>>(json)
                   ?? new List<T>();

            // For Skipping case sensitive comparing from json file & property name

            //return JsonSerializer.Deserialize<List<T>>(json,
            //   new JsonSerializerOptions 
            //   {
            //       PropertyNameCaseInsensitive = true
            //   }) ?? new List<T>();
        }
    }
}
