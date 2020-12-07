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
    public class BankController : ControllerBase
    {
        private readonly APIDbContext _context;

        public BankController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/Bank
        [HttpGet]
        public IEnumerable<CBank> GetBanks()
        {
            return _context.Banks;
        }

        // GET: api/Bank/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCBank([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cBank = await _context.Banks.FindAsync(id);

            if (cBank == null)
            {
                return NotFound();
            }

            return Ok(cBank);
        }

        // PUT: api/Bank/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCBank([FromRoute] int id, [FromBody] CBank cBank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cBank.fBankId)
            {
                return BadRequest();
            }

            _context.Entry(cBank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CBankExists(id))
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

        // POST: api/Bank
        [HttpPost]
        public async Task<IActionResult> PostCBank([FromBody] CBank cBank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Banks.Add(cBank);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCBank", new { id = cBank.fBankId }, cBank);
        }

        // DELETE: api/Bank/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCBank([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cBank = await _context.Banks.FindAsync(id);
            if (cBank == null)
            {
                return NotFound();
            }

            _context.Banks.Remove(cBank);
            await _context.SaveChangesAsync();

            return Ok(cBank);
        }

        private bool CBankExists(int id)
        {
            return _context.Banks.Any(e => e.fBankId == id);
        }
    }
}