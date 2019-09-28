using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dot_net_academy_asp_mvc.Models.Entity;

namespace dot_net_academy_asp_mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkersController : ControllerBase
    {
        private readonly MarkersDb _context;

        public MarkersController(MarkersDb context)
        {
            _context = context;
        }

        // GET: api/Markers
        [HttpGet]
        public IEnumerable<Marker> GetMarkers()
        {
            return _context.Markers;
        }

        // GET: api/Markers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMarker([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var marker = await _context.Markers.FindAsync(id);

            if (marker == null)
            {
                return NotFound();
            }

            return Ok(marker);
        }

        // PUT: api/Markers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarker([FromRoute] int id, [FromBody] Marker marker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != marker.Id)
            {
                return BadRequest();
            }

            _context.Entry(marker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarkerExists(id))
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

        // POST: api/Markers
        [HttpPost]
        public async Task<IActionResult> PostMarker([FromForm] Marker marker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Markers.Add(marker);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Markers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarker([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var marker = await _context.Markers.FindAsync(id);
            if (marker == null)
            {
                return NotFound();
            }

            _context.Markers.Remove(marker);
            await _context.SaveChangesAsync();

            return Ok(marker);
        }

        private bool MarkerExists(int id)
        {
            return _context.Markers.Any(e => e.Id == id);
        }
    }
}