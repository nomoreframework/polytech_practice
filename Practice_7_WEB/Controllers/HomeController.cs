using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practice_7_WEB.Models;
using Practice_7_WEB.Models.InitialModelsDB;
using Microsoft.EntityFrameworkCore;
using Practice_7_WEB.Services.InitialDBService;

namespace Practice_7_WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        InitialDbService service;
        private readonly DBContext db;
        public HomeController(DBContext dBContext)
        {
            db = dBContext;
            service = new InitialDbService(db);
            service.InitialDatabse();
        }
        [HttpPost]
        public async Task<IActionResult>  GetInstruments()
        {
            var instruments = await db.Instruments
                .Include(d => d.Drills)
                .Include(c => c.Circulars).ToListAsync();
                
            return Ok(instruments);
        }
    }
}
