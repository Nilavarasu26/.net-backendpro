using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactProject.Models;

namespace ReactProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DCandidateController : ControllerBase
    {
        private readonly DbContextCandidate _context;

        public DCandidateController(DbContextCandidate context)
        {
            _context = context;
        }

        // GET: api/dcandidate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DCandidate>>> GetCandidates()
        {
            return await _context.dCandidates.ToListAsync();
        }

        // GET: api/dcandidate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DCandidate>> GetCandidate(int id)
        {
            var candidate = await _context.dCandidates.FindAsync(id);

            if (candidate == null)
            {
                return NotFound();
            }

            return candidate;
        }

        // POST: api/dcandidate
        [HttpPost]
        public async Task<ActionResult<DCandidate>> PostCandidate(DCandidate candidate)
        {
            _context.dCandidates.Add(candidate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidate", new { id = candidate.Id }, candidate);
        }

        // PUT: api/dcandidate/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidate(int id, DCandidate candidate)
        {
            
            _context.Entry(candidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(id))
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

        // DELETE: api/dcandidate/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            var candidate = await _context.dCandidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            _context.dCandidates.Remove(candidate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CandidateExists(int id)
        {
            return _context.dCandidates.Any(e => e.Id == id);
        }
    }
    }
