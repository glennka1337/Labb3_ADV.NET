using Labb3_ADV.NET.Data;
using Labb3_ADV.NET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb3_ADV.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PersonsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAllPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        [HttpGet("{id}/interests")]
        public async Task<ActionResult<IEnumerable<Interest>>> GetPersonInterests(int id)
        {
            var interests = await _context.PersonInterests
                .Where(pi => pi.PersonId == id)
                .Select(pi => pi.Interest)
                .ToListAsync();

            return interests;
        }

        [HttpGet("{id}/links")]
        public async Task<ActionResult<IEnumerable<Link>>> GetLinksForPerson(int id)
        {
            var links = await _context.Links
                .Where(l => l.PersonId == id)
                .ToListAsync();

            return links;
        }

        [HttpPost("{id}/interests")]
        public async Task<IActionResult> AddInterestToPerson(int id, [FromBody] int interestId)
        {
            var exists = await _context.PersonInterests.AnyAsync(pi => pi.PersonId == id && pi.InterestId == interestId);
            if (!exists)
            {
                _context.PersonInterests.Add(new PersonInterest
                {
                    PersonId = id,
                    InterestId = interestId
                });
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpPost("{id}/interests/{interestId}/links")]
        public async Task<IActionResult> AddLink(int id, int interestId, [FromBody] string url)
        {
            var personInterest = await _context.PersonInterests
                .FirstOrDefaultAsync(pi => pi.PersonId == id && pi.InterestId == interestId);

            if (personInterest == null) return NotFound();

            _context.Links.Add(new Link
            {
                PersonId = id,
                InterestId = interestId,
                Url = url
            });

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
