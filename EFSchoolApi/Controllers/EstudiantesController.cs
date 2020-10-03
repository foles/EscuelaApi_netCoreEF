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
    public class EstudiantesController : ControllerBase
    {
        

        // GET: api/Estudiantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiante()
        {
            using (var _context = new SchoolDBContext())
            {
                return await _context.Estudiante.ToListAsync();
            }
        }

        // GET: api/Estudiantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
        {
            using (var _context = new SchoolDBContext())
            {
                var estudiante = await _context.Estudiante.FindAsync(id);

                if (estudiante == null)
                {
                    return NotFound();
                }

                return estudiante;
            }
        }

        // PUT: api/Estudiantes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, Estudiante estudiante)
        {
            using (var _context = new SchoolDBContext())
            {
                if (id != estudiante.Id)
                {
                    return BadRequest();
                }

                _context.Entry(estudiante).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(id))
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

        // POST: api/Estudiantes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante estudiante)
        {
            using (var _context = new SchoolDBContext())
            {
                _context.Estudiante.Add(estudiante);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEstudiante", new { id = estudiante.Id }, estudiante);
            }
           }

        // DELETE: api/Estudiantes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Estudiante>> DeleteEstudiante(int id)
        {
            using (var _context = new SchoolDBContext())
            {
                var estudiante = await _context.Estudiante.FindAsync(id);
                if (estudiante == null)
                {
                    return NotFound();
                }

                _context.Estudiante.Remove(estudiante);
                await _context.SaveChangesAsync();

                return estudiante;
            }
        }

        private bool EstudianteExists(int id)
        {
            using (var _context = new SchoolDBContext())
            {
                return _context.Estudiante.Any(e => e.Id == id);
            }
        }
    }
}
