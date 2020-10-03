﻿using System;
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
    public class MateriasController : ControllerBase
    {
        

        // GET: api/Materias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materia>>> GetMateria()
        {
            using (var _context = new SchoolDBContext())
            {
                return await _context.Materia.ToListAsync();
            }
        }

        // GET: api/Materias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Materia>> GetMateria(int id)
        {
            using (var _context = new SchoolDBContext())
            {
                var materia = await _context.Materia.FindAsync(id);

                if (materia == null)
                {
                    return NotFound();
                }

                return materia;
            }
        }

        // PUT: api/Materias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateria(int id, Materia materia)
        {
            using (var _context = new SchoolDBContext())
            {
                if (id != materia.Id)
                {
                    return BadRequest();
                }

                _context.Entry(materia).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaExists(id))
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

        // POST: api/Materias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Materia>> PostMateria(Materia materia)
        {
            using (var _context = new SchoolDBContext())
            {
                _context.Materia.Add(materia);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetMateria", new { id = materia.Id }, materia);
            }
        }

        // DELETE: api/Materias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Materia>> DeleteMateria(int id)
        {
            using (var _context = new SchoolDBContext())
            {
                var materia = await _context.Materia.FindAsync(id);
                if (materia == null)
                {
                    return NotFound();
                }

                _context.Materia.Remove(materia);
                await _context.SaveChangesAsync();

                return materia;
            }
        }

        private bool MateriaExists(int id)
        {
            using (var _context = new SchoolDBContext())
            {
                return _context.Materia.Any(e => e.Id == id);
            }
        }
    }
}
