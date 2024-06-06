using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendAPI.Data;
using BackendAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class HistoricController : ControllerBase
    {
        private readonly BackendAPIContext _context;

        public HistoricController(BackendAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Historic>>> GetHistorics()
        {
            return await _context.Historicals.Include(h => h.Receipt).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Historic>> GetHistoric(int id)
        {
            var historic = await _context.Historicals.Include(h => h.Receipt).FirstOrDefaultAsync(h => h.Id == id);

            if (historic == null) return NotFound();

            return historic;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoric(int id, Historic historic)
        {
            var existingHistoric = await _context.Historicals.Include(h => h.Receipt).FirstOrDefaultAsync(h => h.Id == id);

            if (existingHistoric == null) return NotFound();

            existingHistoric.Description = historic.Description;
            existingHistoric.ServiceDate = historic.ServiceDate;
            existingHistoric.ServiceType = historic.ServiceType;

            if (existingHistoric.Receipt != null && historic.Receipt != null)
            {
                existingHistoric.Receipt.Cost = historic.Receipt.Cost;
                existingHistoric.Receipt.AmountCharged = historic.Receipt.AmountCharged;
            }

            _context.Entry(existingHistoric).State = EntityState.Modified;

            if (existingHistoric.Receipt != null) _context.Entry(existingHistoric.Receipt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoricExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Historic>> PostHistoric(Historic historic)
        {
            _context.Historicals.Add(historic);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHistoric), new { id = historic.Id }, historic);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoric(int id)
        {
            var historic = await _context.Historicals.FindAsync(id);

            if (historic == null) return NotFound();

            _context.Historicals.Remove(historic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoricExists(int id)
        {
            return _context.Historicals.Any(e => e.Id == id);
        }
    }
}
