using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIIInlinetable.Models;

namespace WebAPIIInlinetable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly APIDbContext _context;

        public BankAccountController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/BankAccount
        [HttpGet]
        public IEnumerable<CBankAccount> GetBankAccounts()
        {
            return _context.BankAccounts;
        }

        // GET: api/BankAccount/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCBankAccount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cBankAccount = await _context.BankAccounts.FindAsync(id);

            if (cBankAccount == null)
            {
                return NotFound();
            }

            return Ok(cBankAccount);
        }

        // PUT: api/BankAccount/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCBankAccount([FromRoute] int id, [FromBody] CBankAccount cBankAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cBankAccount.fBankAccountId)
            {
                return BadRequest();
            }

            _context.Entry(cBankAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CBankAccountExists(id))
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

        // POST: api/BankAccount
        [HttpPost]
        public async Task<IActionResult> PostCBankAccount([FromBody] CBankAccount cBankAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BankAccounts.Add(cBankAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCBankAccount", new { id = cBankAccount.fBankAccountId }, cBankAccount);
        }

        // DELETE: api/BankAccount/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCBankAccount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cBankAccount = await _context.BankAccounts.FindAsync(id);
            if (cBankAccount == null)
            {
                return NotFound();
            }

            _context.BankAccounts.Remove(cBankAccount);
            await _context.SaveChangesAsync();

            return Ok(cBankAccount);
        }

        private bool CBankAccountExists(int id)
        {
            return _context.BankAccounts.Any(e => e.fBankAccountId == id);
        }
    }
}