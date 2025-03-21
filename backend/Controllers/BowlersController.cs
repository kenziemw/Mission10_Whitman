// Weston Watson, Section 3

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BowlingAPI.Data;
using BowlingAPI.Models;

namespace BowlingAPI.Controllers
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
            var bowlers = await _context.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team != null && (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")) // Check this
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

            return Ok(bowlers);
        }
    }
}
