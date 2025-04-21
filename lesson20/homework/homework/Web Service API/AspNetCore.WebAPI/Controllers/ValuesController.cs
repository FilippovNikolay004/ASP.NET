using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCore.WebAPI.Models;

namespace AspNetCore.WebAPI.Controllers
{
    [ApiController]
    [Route("api/Music")]
    public class MusicController : ControllerBase
    {
        private readonly MusicContext _context;

        public MusicController(MusicContext context)
        {
            _context = context;
        }

        // GET: api/Music
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Music>>> GetMusic()
        {
            return await _context.Musics.ToListAsync();
        }

        // GET: api/Music/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Music>> GetMusic(int id)
        {
            var music = await _context.Musics.SingleOrDefaultAsync(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }
            return new ObjectResult(music);
        }

        // PUT: api/Music
        [HttpPut]
        public async Task<ActionResult<Music>> PutStudent(Music music)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_context.Musics.Any(e => e.Id == music.Id))
            {
                return NotFound();
            }

            _context.Update(music);
            await _context.SaveChangesAsync();
            return Ok(music);
        }

        // POST: api/Music
        [HttpPost]
        public async Task<ActionResult<Music>> PostStudent(Music music)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Musics.Add(music);
            await _context.SaveChangesAsync();

            return Ok(music);
        }

        // DELETE: api/Music/3
        [HttpDelete("{id}")]
        public async Task<ActionResult<Music>> DeleteMusic(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var music = await _context.Musics.SingleOrDefaultAsync(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }

            _context.Musics.Remove(music);
            await _context.SaveChangesAsync();

            return Ok(music);
        }
    }
}
