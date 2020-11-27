using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DCandidateController : ControllerBase
    {
        private readonly DonationDbContext _context;

        public DCandidateController(DonationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DCandidate>>> GetDCandidate()
        {
            return await _context.DCandidates.ToListAsync();
        }

        //GET: api/DCandidate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DCandidate>> GetDCandidate(int id)
        {
            var dCandidate = await _context.DCandidates.FindAsync(id);
            if (dCandidate == null)
                return NotFound();
            return dCandidate;
        }

        //PUT: api/DCandidate/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, DCandidate dcandidate)
        {
            dcandidate.fID = id;
            _context.Entry(dcandidate).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DCandidateExists(id))
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

        //POST: api/DCandidate
        [HttpPost]
        public async Task<ActionResult<DCandidate>> PostDCandidate(DCandidate dcandidate)
        {
            _context.DCandidates.Add(dcandidate);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDCandidate", new { id = dcandidate.fID},dcandidate);
        }

        //DELETE: api/DCandidate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DCandidate>> DeleteDCandidate(int id)
        {
            var dCandidate = await _context.DCandidates.FindAsync(id);
            if (dCandidate == null)
                return NotFound();
            _context.DCandidates.Remove(dCandidate);
            await _context.SaveChangesAsync();
            return dCandidate;
        }

        private bool DCandidateExists(int id)
        {
            return _context.DCandidates.Any(a=>a.fID == id);
        }
    }
}
