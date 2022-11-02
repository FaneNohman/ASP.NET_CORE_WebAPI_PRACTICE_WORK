using Microsoft.EntityFrameworkCore;

namespace WebApplication_Test_Work.Models
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<USDtoCurrency> Currencies { get; set; }
    }
}
