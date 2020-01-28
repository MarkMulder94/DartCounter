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
    [Route("api/[controller]")]
    [ApiController]
    public class GameModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GameModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GameModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameModel>>> GetGames()
        {
            return await _context.Games.ToListAsync();
        }

        // GET: api/GameModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameModel>> GetGameModel(int id)
        {
            var gameModel = await _context.Games.FindAsync(id);

            if (gameModel == null)
            {
                return NotFound();
            }

            return gameModel;
        }

        // PUT: api/GameModels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameModel(int id, GameModel gameModel)
        {
            if (id != gameModel.Game_Id)
            {
                return BadRequest();
            }

            _context.Entry(gameModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameModelExists(id))
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

        // POST: api/GameModels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GameModel>> PostGameModel(GameModel gameModel)
        {
            _context.Games.Add(gameModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameModel", new { id = gameModel.Game_Id }, gameModel);
        }

        // DELETE: api/GameModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GameModel>> DeleteGameModel(int id)
        {
            var gameModel = await _context.Games.FindAsync(id);
            if (gameModel == null)
            {
                return NotFound();
            }

            _context.Games.Remove(gameModel);
            await _context.SaveChangesAsync();

            return gameModel;
        }

        private bool GameModelExists(int id)
        {
            return _context.Games.Any(e => e.Game_Id == id);
        }
    }
}
