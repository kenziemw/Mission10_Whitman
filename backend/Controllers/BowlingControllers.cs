using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;  
using backend.Models; 
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace backend.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlersController : ControllerBase
    {
        private readonly BowlingContext _context;

        public BowlersController(BowlingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBowlers()
        {
            if (_context.Bowlers == null || !_context.Bowlers.Any())
            {
                return NotFound("No bowlers found in the database.");
            }

            var bowlers = await _context.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team != null && 
                            (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks"))
                .Select(b => new
                {
                    Name = $"{b.BowlerFirstName} {b.BowlerMiddleInit} {b.BowlerLastName}",
                    Team = b.Team.TeamName,
                    Address = b.BowlerAddress,
                    City = b.BowlerCity,
                    State = b.BowlerState,
                    Zip = b.BowlerZip,
                    Phone = b.BowlerPhoneNumber
                })
                .ToListAsync();

            if (!bowlers.Any())
            {
                return NotFound("No bowlers found for the Marlins or Sharks teams.");
            }

            return Ok(bowlers);
        }
    }
}
