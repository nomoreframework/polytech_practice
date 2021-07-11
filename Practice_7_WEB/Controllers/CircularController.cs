using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice_7_WEB.Models;
using Practice_7_WEB.Services.InitialDBService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_7_WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircularController : ControllerBase
    {
        InitialDbService service;
        private readonly DBContext db;
        public CircularController(DBContext dBContext)
        {
            db = dBContext;
            service = new InitialDbService(db);
            service.InitialDatabse();
        }

        [HttpGet]
        public async Task<IActionResult> GetCircularsInRange(int id)
        {
            var circulars = await db.Circulars.Skip(id).Take(10).ToListAsync();
            return Ok(circulars);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCircular(int id)
        {
            var circular = await db.Circulars.FirstOrDefaultAsync(c => c.Id == id);
            if (circular == null) return NotFound();
            return Ok(circular);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCircular(int id)
        {
            var circular = await db.Circulars.FirstOrDefaultAsync(c => c.Id == id);
            if (circular == null) return NotFound(circular);
            db.Circulars.Remove(circular);
            await db.SaveChangesAsync();
            return Ok($"object {circular} was deleted!");
        }
        [HttpPost]
        public async Task<IActionResult> AddCircular(Circular circular)
        {
            if (circular == null) return BadRequest();
            db.Circulars.Add(circular);
            await db.SaveChangesAsync();
            return Ok($"object {circular} was added!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDrill(Circular circular)
        {
            if (circular == null)
            {
                return BadRequest();
            }
            if (!db.Circulars.Any(c => c.Id == circular.Id))
            {
                return NotFound();
            }

            db.Update(circular);
            await db.SaveChangesAsync();
            return Ok(($"object {circular} was updated!"));
        }
    }
}
