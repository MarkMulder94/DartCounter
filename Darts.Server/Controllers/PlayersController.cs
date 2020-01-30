using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Darts.Lib.Models;
using Darts.Server.Data;

namespace Darts.Server.Controllers
{
    [Route("players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlayersController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerModel>>> GetUserModels()
        {
            return await _context.UserModels.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerModel>> GetPlayerModel(int id)
        {
            var playerModel = await _context.UserModels.FindAsync(id);

            if (playerModel == null)
            {
                return NotFound();
            }

            return playerModel;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerModel(int id, PlayerModel playerModel)
        {
            if (id != playerModel.Player_Id)
            {
                return BadRequest();
            }

            _context.Entry(playerModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerModelExists(id))
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
        [HttpPost]
        public async Task<ActionResult<PlayerModel>> PostPlayerModel(PlayerModel playerModel)
        {
            _context.UserModels.Add(playerModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayerModel", new { id = playerModel.Player_Id }, playerModel);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlayerModel>> DeletePlayerModel(int id)
        {
            var playerModel = await _context.UserModels.FindAsync(id);
            if (playerModel == null)
            {
                return NotFound();
            }

            _context.UserModels.Remove(playerModel);
            await _context.SaveChangesAsync();

            return playerModel;
        }
        private bool PlayerModelExists(int id)
        {
            return _context.UserModels.Any(e => e.Player_Id == id);
        }
    }
}
