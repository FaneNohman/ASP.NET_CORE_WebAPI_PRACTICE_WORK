using Microsoft.EntityFrameworkCore;

namespace WebApplication_Test_Work.Models
{
    public class CurrenciesSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DBContext(serviceProvider.GetRequiredService<DbContextOptions<DBContext>>()))
            {
                if (context.Currencies.Any())
                {
                    return;
                }
                context.Currencies.AddRange(new USDtoCurrency {CurrencyName="KZT",Price= 467.31663m },new USDtoCurrency { CurrencyName="EUR",Price= 1.009665m },new USDtoCurrency { CurrencyName="CNY",Price= 7.3007544m });
                context.SaveChanges();
            }

        }
    }
}
