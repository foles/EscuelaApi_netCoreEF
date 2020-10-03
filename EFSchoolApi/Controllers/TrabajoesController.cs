using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFSchoolApi.Models;

namespace EFSchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajoesController : ControllerBase
    {
       

        // GET: api/Trabajoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trabajo>>> GetTrabajo()
        {
            using (var _context = new SchoolDBContext())
            {
                return await _context.Trabajo.ToListAsync();
            }
        }

        // GET: api/Trabajoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trabajo>> GetTrabajo(int id)
        {
            using (var _context = new SchoolDBContext())
            {
                var trabajo = await _context.Trabajo.FindAsync(id);

                if (trabajo == null)
                {
                    return NotFound();
                }

                return trabajo;
            }
        }

        // PUT: api/Trabajoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrabajo(int id, Trabajo trabajo)
        {
            using (var _context = new SchoolDBContext())
            {
                if (id != trabajo.Id)
                {
                    return BadRequest();
                }

                _context.Entry(trabajo).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrabajoExists(id))
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
        }

        // POST: api/Trabajoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Trabajo>> PostTrabajo(Trabajo trabajo)
        {
            using (var _context = new SchoolDBContext())
            {
                _context.Trabajo.Add(trabajo);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTrabajo", new { id = trabajo.Id }, trabajo);
            }
        }

        // DELETE: api/Trabajoes/5
        [HttpDelete("{id}")]

        public async Task<ActionResult<Trabajo>> DeleteTrabajo(int id)
        {
            using (var _context = new SchoolDBContext())
            {
                var trabajo = await _context.Trabajo.FindAsync(id);
                if (trabajo == null)
                {
                    return NotFound();
                }

                _context.Trabajo.Remove(trabajo);
                await _context.SaveChangesAsync();

                return trabajo;
            }
        }

        private bool TrabajoExists(int id)
        {
            using (var _context = new SchoolDBContext())
            {
                return _context.Trabajo.Any(e => e.Id == id);
            }
        }
    }
}
