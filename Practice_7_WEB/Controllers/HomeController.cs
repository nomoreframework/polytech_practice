using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practice_7_WEB.Models;
using Practice_7_WEB.Models.InitialModelsDB;
using Microsoft.EntityFrameworkCore;

namespace Practice_7_WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private DBContext db;
        private dataManager data;
        public HomeController(DBContext dBContext)
        {
            db = dBContext;

            if(!db.Instruments.Any())
            {            
                    data = new dataManager();
                    Instrument makita = new Instrument { Manufacturer = "Makita" };
                    Instrument bosh = new Instrument {Manufacturer = "Bosh" };
                    makita.Circulars.AddRange(data.GetCirculars(makita));
                    makita.Drills.AddRange(data.GetDrills(makita));
                    bosh.Drills.AddRange(data.GetDrills(bosh));
                    bosh.Circulars.AddRange(data.GetCirculars(bosh));
                    db.Instruments.Add(makita);
                    db.Instruments.Add(bosh);

                    db.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var instruments =  await db.Instruments.Include(d => d.Drills).Include(c => c.Circulars).ToListAsync();
            return Ok(instruments);
        }
    }
}
