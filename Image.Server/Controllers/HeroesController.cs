using Image.Server.Context;
using Image.Server.Entities;
using Image.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/*Online ref: https://code-maze.com/net-core-series/ */

namespace Image.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroesRepository _heroesRepository;

        public HeroesController(IHeroesRepository heroesRepository)
        {
            _heroesRepository = heroesRepository ??
                throw new ArgumentNullException(nameof(heroesRepository));
        }

        // GET: api/Heroes
        [HttpGet]
        public async Task<IActionResult> GetHeroes()
        {
            var results = await _heroesRepository.GetHeroesAsync();

            return Ok(results);
        }

        // GET: api/Heroes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHero([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hero = await _heroesRepository.GetHeroAsync(id);

            if (hero == null)
            {
                return NotFound();
            }

            return Ok(hero);
        }

        // PUT: api/Heroes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHero([FromRoute] int id, [FromBody] Hero hero)
        {
            if (hero == null)
            {
                //_logger.LogError("Hero  object sent from client is null.");
                return BadRequest("Hero object is null");
            }


            if (!ModelState.IsValid)
            {
                //_logger.LogError("Invalid hero object sent from client.");
                return BadRequest(ModelState);
            }

            if (id != hero.Id)
            {
                // _logger.LogError("Unknown hero object sent from client.");
                return BadRequest();
            }

            var dbHero = await _heroesRepository.GetHeroAsync(id);
            if (dbHero == null)
            {
                //_logger.LoggerError($"Hero with id: {id}, hasn't been found in db.")
                return NotFound();
            }

            //await _heroesRepository.UpdateHero(dbHero, hero);

            return NoContent();
        }

        /*
        // POST: api/Heroes
        [HttpPost]
        public async Task<IActionResult> PostHero([FromBody] Hero hero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHero", new { id = hero.Id }, hero);
        }

        // DELETE: api/Heroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();

            return Ok(hero);
        }

        private bool HeroExists(int id)
        {
            return _context.Heroes.Any(e => e.Id == id);
        }
        */
    }
}
