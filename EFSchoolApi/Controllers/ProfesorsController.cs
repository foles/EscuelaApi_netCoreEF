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
    public class ProfesorsController : ControllerBase
    {
        
        // GET: api/Profesors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesor>>> GetProfesor()
        {
            using (var _context = new SchoolDBContext())
            {
                return await _context.Profesor.ToListAsync();
            }
        }

        // GET: api/Profesors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesor>> GetProfesor(int id)
        {
            using (var _context = new SchoolDBContext())
            {
                var profesor = await _context.Profesor.FindAsync(id);

                if (profesor == null)
                {
                    return NotFound();
                }

                return profesor;
            }
        }

        // PUT: api/Profesors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesor(int id, Profesor profesor)
        {
            using (var _context = new SchoolDBContext())
            {
                if (id != profesor.Id)
                {
                    return BadRequest();
                }

                _context.Entry(profesor).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesorExists(id))
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

        // POST: api/Profesors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Profesor>> PostProfesor(Profesor profesor)
        {
            using (var _context = new SchoolDBContext())
            {
                _context.Profesor.Add(profesor);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProfesor", new { id = profesor.Id }, profesor);
            }
        }

        // DELETE: api/Profesors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Profesor>> DeleteProfesor(int id)
        {
            using (var _context = new SchoolDBContext())
            {
                var profesor = await _context.Profesor.FindAsync(id);
                if (profesor == null)
                {
                    return NotFound();
                }

                _context.Profesor.Remove(profesor);
                await _context.SaveChangesAsync();

                return profesor;
            }
        }

        private bool ProfesorExists(int id)
        {
            using (var _context = new SchoolDBContext())
            {
                return _context.Profesor.Any(e => e.Id == id);
            }
        }
    }
}
