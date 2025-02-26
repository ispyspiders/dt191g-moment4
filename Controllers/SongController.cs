using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaylistApp.Data;
using PlaylistApp.Models;

namespace PlaylistApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly PlaylistContext _context;

        public SongController(PlaylistContext context)
        {
            _context = context;
        }

        // GET: api/Song
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongDto>>> GetSongs()
        {
            var songs = await _context.Songs
            .Include(s => s.Category)
            .ToListAsync();

            var songDtos = songs.Select(song => new SongDto
            {
                Id = song.Id,
                Artist = song.Artist,
                Title = song.Title,
                Length = song.Length,
                Category = new CategoryDto
                {
                    Id = song.Category.Id,
                    Name = song.Category.Name
                }
            }).ToList();
            return Ok(songDtos);
        }

        // GET: api/Song/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongDto>> GetSong(int id)
        {
            var song = await _context.Songs
            .Include(s => s.Category)
            .FirstOrDefaultAsync(s => s.Id == id);

            if (song == null)
            {
                return NotFound();
            }

            var songDto = new SongDto
            {
                Id = song.Id,
                Artist = song.Artist,
                Title = song.Title,
                Length = song.Length,
                Category = new CategoryDto
                {
                    Id = song.Category.Id,
                    Name = song.Category.Name
                }
            };

            return Ok(songDto);
        }

        // PUT: api/Song/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, Song song)
        {
            if (id != song.Id)
            {
                return BadRequest();
            }

            _context.Entry(song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
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

        // POST: api/Song
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SongDto>> PostSong(SongDto songDto)
        {
            // Kontroll om kategori-ID finns i db
            var category = await _context.Categories.FindAsync(songDto.CategoryId);
            if (category == null)
            {
                return BadRequest("Kategori med det angivna ID finns inte.");
            }

            // Skapa en ny Song-modell baserat på DTO:n
            var song = new Song
            {
                Artist = songDto.Artist,
                Title = songDto.Title,
                Length = songDto.Length,
                CategoryId = songDto.CategoryId
            };

            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            var songDtoResult = new SongDto
            {
                Id = song.Id,
                Artist = song.Artist,
                Title = song.Title,
                Length = song.Length,
                CategoryId = song.CategoryId,
                Category = new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                }
            };

            return CreatedAtAction("GetSong", new { id = song.Id }, songDtoResult);
        }

        // DELETE: api/Song/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.Id == id);
        }
    }
}
