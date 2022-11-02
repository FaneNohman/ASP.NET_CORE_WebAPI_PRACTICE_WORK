using Microsoft.EntityFrameworkCore;

namespace WebApplication_Test_Work.Models
{
    public class DepositSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DBContext(serviceProvider.GetRequiredService<DbContextOptions<DBContext>>()))
            {
                if (context.Deposits.Any())
                {
                    return;
                }
                context.Deposits.AddRange(new Deposit {FromAccount="denis_123",ToAccount="denis_321",SumUSD=100m },new Deposit { FromAccount = "denis_123", ToAccount = "denis_321", SumUSD = 100m });
                context.SaveChanges();
            }

        }
    }
}
