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
    public class EscuelasController : ControllerBase
    {
        

        // GET: api/Escuelas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Escuela>>> GetEscuela()
        {
            using (var _context = new SchoolDBContext())
            {
                return await _context.Escuela.ToListAsync();
            }
        }

        // GET: api/Escuelas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Escuela>> GetEscuela(int id)
        {
            using (var _context = new SchoolDBContext())
            {
                var escuela = await _context.Escuela.FindAsync(id);

                if (escuela == null)
                {
                    return NotFound();
                }

                return escuela;
            }
        }

        // PUT: api/Escuelas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEscuela(int id, Escuela escuela)
        {
            using (var _context = new SchoolDBContext())
            {
                if (id != escuela.Id)
                {
                    return BadRequest();
                }

                _context.Entry(escuela).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscuelaExists(id))
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

        // POST: api/Escuelas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Escuela>> PostEscuela(Escuela escuela)
        {
            using (var _context = new SchoolDBContext())
            {
                _context.Escuela.Add(escuela);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEscuela", new { id = escuela.Id }, escuela);
            }
        }

        // DELETE: api/Escuelas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Escuela>> DeleteEscuela(int id)
        {
            using (var _context = new SchoolDBContext())
            {
                var escuela = await _context.Escuela.FindAsync(id);
                if (escuela == null)
                {
                    return NotFound();
                }

                _context.Escuela.Remove(escuela);
                await _context.SaveChangesAsync();

                return escuela;
            }
        }

        private bool EscuelaExists(int id)
        {
            using (var _context = new SchoolDBContext())
            {
                return _context.Escuela.Any(e => e.Id == id);
            }
        }
    }
}
