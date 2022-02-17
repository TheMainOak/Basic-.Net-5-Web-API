using Athletes_Web_API.Data;
using Athletes_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Athletes_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthleteController : ControllerBase
    {
        private readonly DataContext _context;
        public AthleteController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Athlete>>> GetAll()
        {
            return Ok(await _context.Athletes.ToListAsync()); //Return status code 200 with the OK, BadRequest = 400 and NotFound = 404.
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Athlete>> GetByID(int id)
        {
            var athlete = await _context.Athletes.FindAsync(id);

            if(athlete == null)
            {
                return BadRequest("Athlete not found.");
            }
            else
            {
                return Ok(athlete);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Athlete>>> AddAthlete(Athlete athlete)
        {
            _context.Athletes.Add(athlete);
            await _context.SaveChangesAsync();

            return Ok(await _context.Athletes.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Athlete>>> Delete(int id)
        {
            var ath = await _context.Athletes.FindAsync(id);

            if (ath == null)
            {
                return BadRequest("Athlete not found.");
            }
            else
            {
                _context.Athletes.Remove(ath);

                await _context.SaveChangesAsync();

                return Ok(await _context.Athletes.ToListAsync());
            }
        }
            

        [HttpPut]
        public async Task<ActionResult<List<Athlete>>> UpdateAthlete(Athlete athlete)
        {
            var ath = await _context.Athletes.FindAsync(athlete.ID);

            if (ath == null)
            {
                return BadRequest("Athlete not found.");
            }
            else
            {
                ath.FirstName = athlete.FirstName;
                ath.Surname = athlete.Surname;
                ath.Sport = athlete.Sport;
                ath.Age = athlete.Age;

                await _context.SaveChangesAsync();

                return Ok(await _context.Athletes.ToListAsync());
            }

        }
    }
}
