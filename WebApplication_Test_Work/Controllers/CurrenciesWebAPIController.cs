using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication_Test_Work.Models;

namespace WebApplication_Test_Work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesWebAPIController : ControllerBase
    {
        private readonly DBContext _context;

        public CurrenciesWebAPIController(DBContext context)
        {
            _context = context;
        }

        // GET: api/CurrenciesWebAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<USDtoCurrency>>> GetCurrencies()
        {
            return await _context.Currencies.ToListAsync();
        }

        // GET: api/CurrenciesWebAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<USDtoCurrency>> GetUSDtoCurrency(Guid id)
        {
            var uSDtoCurrency = await _context.Currencies.FindAsync(id);

            if (uSDtoCurrency == null)
            {
                return NotFound();
            }

            return uSDtoCurrency;
        }

        // PUT: api/CurrenciesWebAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUSDtoCurrency(Guid id, USDtoCurrency uSDtoCurrency)
        {
            if (id != uSDtoCurrency.USDtoCurrencyId)
            {
                return BadRequest();
            }

            _context.Entry(uSDtoCurrency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USDtoCurrencyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CurrenciesWebAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<USDtoCurrency>> PostUSDtoCurrency(USDtoCurrency uSDtoCurrency)
        {
            _context.Currencies.Add(uSDtoCurrency);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUSDtoCurrency", new { id = uSDtoCurrency.USDtoCurrencyId }, uSDtoCurrency);
        }

        // DELETE: api/CurrenciesWebAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUSDtoCurrency(Guid id)
        {
            var uSDtoCurrency = await _context.Currencies.FindAsync(id);
            if (uSDtoCurrency == null)
            {
                return NotFound();
            }

            _context.Currencies.Remove(uSDtoCurrency);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool USDtoCurrencyExists(Guid id)
        {
            return _context.Currencies.Any(e => e.USDtoCurrencyId == id);
        }
    }
}
