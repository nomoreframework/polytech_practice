using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practice_7_WEB.Models;
using Practice_7_WEB.Models.InitialModelsDB;

namespace Practice_7_WEB.Services.InitialDBService
{
    public class InitialDbService : InitialDBService
    {
        DBContext db;
        private dataManager data;
        public InitialDbService(DBContext dBContext)
        {
            db = dBContext;
        }
        public void InitialDatabse()
        {
            if (!db.Instruments.Any())
            {
                data = new dataManager();
                Instrument makita = new Instrument { Manufacturer = "Makita" };
                Instrument bosh = new Instrument { Manufacturer = "Bosh" };
                makita.Circulars.AddRange(data.GetCirculars(makita));
                makita.Drills.AddRange(data.GetDrills(makita));
                bosh.Drills.AddRange(data.GetDrills(bosh));
                bosh.Circulars.AddRange(data.GetCirculars(bosh));
                db.Instruments.Add(makita);
                db.Instruments.Add(bosh);

                db.SaveChanges();
            }
        }
    }
}
