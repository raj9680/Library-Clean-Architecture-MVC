using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(
            DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }
    }
}
