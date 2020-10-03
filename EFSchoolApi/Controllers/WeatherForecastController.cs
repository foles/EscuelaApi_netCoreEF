using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFSchoolApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFSchoolApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
      
     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Escuela>>> GetEscuela()
        {
            using (var _context = new SchoolDBContext())
            {
                return await _context.Escuela.ToListAsync();
            }
        }
       

        

       
     
    }
}
