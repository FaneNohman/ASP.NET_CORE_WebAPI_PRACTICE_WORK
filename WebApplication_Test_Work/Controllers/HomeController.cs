using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication_Test_Work.Models;

namespace WebApplication_Test_Work.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBContext _dbContext;

        public HomeController(ILogger<HomeController> logger, DBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Currencies.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> CurrencyCalc()
        {
            var currency = await _dbContext.Currencies.ToListAsync();
            if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("CurrencyCalc", currency);
            else
            {
                return View("CurrencyCalc", currency);
            }
        }
        public async Task<IActionResult> CurrencyCalcResult(string cur,string usd )
        {
            var currency = await _dbContext.Currencies.ToListAsync();
            decimal res = Decimal.Parse(usd) * Decimal.Parse(cur);
            return PartialView("CurrencyCalcResult",res);
        }
        public async Task<IActionResult> DepositsCalc()
        {
            if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("DepositsCalc");
            else
            {
                return View("DepositsCalc");
            }
        }
        public async Task<IActionResult> DepositsFromAccount(string name)
        {
            var deposits = await _dbContext.Deposits.ToListAsync();
            var res = deposits.Where(x => x.FromAccount == name).Sum(x => x.SumUSD);
            return PartialView("DepositsFromAccount",res);
        }
        public async Task<IActionResult> DepositsToAccount(string name)
        {
            var deposits = await _dbContext.Deposits.ToListAsync();
            var res = deposits.Where(x => x.ToAccount == name).Sum(x => x.SumUSD);
            return PartialView("DepositsFromAccount", res);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}