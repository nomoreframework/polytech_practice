using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practice_7_WEB.Models;
using Microsoft.EntityFrameworkCore;
using Practice_7_WEB.Services.InitialDBService;

namespace Practice_7_WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillController : ControllerBase
    {
        InitialDbService service;
        private readonly DBContext db;
        public DrillController(DBContext dBContext)
        {
            db = dBContext;
            service = new InitialDbService(db);
            service.InitialDatabse();
        }

        [HttpGet]
        public async Task<IActionResult> GetDrilsInrange(int id)
        {
            var drils = await db.Drills.Skip(id).Take(10).ToListAsync();
            return Ok(drils);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDrill(int id)
        {
            var drill = await db.Drills.FirstOrDefaultAsync(d => d.Id == id);
            if (drill == null) return NotFound();
            return Ok(drill);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrill(int id)
        {
            var drill = await db.Drills.FirstOrDefaultAsync(d => d.Id == id);
            if (drill == null) return NotFound(drill);
            db.Drills.Remove(drill);
            await db.SaveChangesAsync();
            return Ok($"object {drill} was deleted!");
        }
        [HttpPost]
        public async Task<IActionResult> AddDrill(Drill drill)
        {
            if (drill == null) return BadRequest();
            db.Drills.Add(drill);
            await db.SaveChangesAsync();
            return Ok($"object {drill} was added!");
        }
        [HttpPut] 
        public async Task<IActionResult> UpdateDrill(Drill drill)
        {
            if (drill == null)
            {
                return BadRequest();
            }
            if (!db.Drills.Any(d => d.Id == drill.Id))
            {
                return NotFound();
            }

            db.Update(drill);
            await db.SaveChangesAsync();
            return Ok(($"object {drill} was updated!"));
        }
    }
}
