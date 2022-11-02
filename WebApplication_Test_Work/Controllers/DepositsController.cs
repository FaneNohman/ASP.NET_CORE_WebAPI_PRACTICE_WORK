using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApplication_Test_Work.Models;

namespace WebApplication_Test_Work.Controllers
{
    public class DepositsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBContext _dbContext;
        public DepositsController(ILogger<HomeController> logger, DBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            
            return View(await _dbContext.Deposits.ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            
            return View(new Deposit());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Deposit deposit)
        {
            try
            {
                    _dbContext.Add(deposit);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
            }

            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "error, can not save changes");
            }

            return View(deposit);
        }
        public async Task<IActionResult> Edit(Guid Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var deposit = await _dbContext.Deposits.FirstOrDefaultAsync(m => m.DepositId == Id);

            if (deposit == null)
            {
                return NotFound();
            }

            return View(deposit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var deposit = await _dbContext.Deposits.FirstOrDefaultAsync(s => s.DepositId == Id);


            if (await TryUpdateModelAsync<Deposit>(
                deposit, "", s => s.FromAccount, s => s.ToAccount, s => s.SumUSD))
            {
                try
                {
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "error, can not save changes");
                }
            }

            return View(deposit);
        }
        public async Task<IActionResult> Delete(Guid id, bool? Savechangeserror = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deposit = await _dbContext.Deposits.AsNoTracking().FirstOrDefaultAsync(m => m.DepositId == id);

            if (deposit == null)
            {
                return NotFound();
            }

            if (Savechangeserror.GetValueOrDefault())
            {
                ViewData["DeleteError"] = "Delete failed";
            }

            return View(deposit);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deposit = await _dbContext.Deposits.FindAsync(id);

            if (deposit == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _dbContext.Deposits.Remove(deposit);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, Savechangeserror = true });
            }
        }


    }
}
