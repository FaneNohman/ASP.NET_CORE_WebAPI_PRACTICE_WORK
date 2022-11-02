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
    public class DepositsWebAPIController : ControllerBase
    {
        private readonly DBContext _context;

        public DepositsWebAPIController(DBContext context)
        {
            _context = context;
        }

        // GET: api/DepositsWebAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deposit>>> GetDeposits()
        {
            return await _context.Deposits.ToListAsync();
        }

        // GET: api/DepositsWebAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deposit>> GetDeposit(Guid id)
        {
            var deposit = await _context.Deposits.FindAsync(id);

            if (deposit == null)
            {
                return NotFound();
            }

            return deposit;
        }

        // PUT: api/DepositsWebAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeposit(Guid id, Deposit deposit)
        {
            if (id != deposit.DepositId)
            {
                return BadRequest();
            }

            _context.Entry(deposit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositExists(id))
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

        // POST: api/DepositsWebAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deposit>> PostDeposit(Deposit deposit)
        {
            _context.Deposits.Add(deposit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeposit", new { id = deposit.DepositId }, deposit);
        }

        // DELETE: api/DepositsWebAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeposit(Guid id)
        {
            var deposit = await _context.Deposits.FindAsync(id);
            if (deposit == null)
            {
                return NotFound();
            }

            _context.Deposits.Remove(deposit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepositExists(Guid id)
        {
            return _context.Deposits.Any(e => e.DepositId == id);
        }
    }
}
