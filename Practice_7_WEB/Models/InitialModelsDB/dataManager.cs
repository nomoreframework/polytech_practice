using System;
using System.Collections.Generic;
using System.Threading;

namespace Practice_7_WEB.Models.InitialModelsDB
{
    internal class dataManager
    {
        private List<Drill> drills;
        private List<Circular> circulars;
        internal List<Drill> GetDrills(Instrument instrument)
        {
            drills = new List<Drill>(50);
            int price = 0;
            int power_watt = 0;
            int series = 0;
            for(int i = 1; i < 50; i++)
            {
                price = new Random().Next(1500, 9990);
                power_watt = new Random().Next(400, 2000);
                power_watt = power_watt - (power_watt % 100);
                price = price - (price % 10);
                series = new Random().Next(400, 800) + i;
                drills.Add(new Drill(instrument)
                {
                    InstrumentId = instrument.Id,
                    Series = series,
                    Discount = (i / 10) * 10,
                    Price = (i / 10) * 10 == 0 ? price : price - price / 100 * ((i % 10) * 10),
                    NameSeries = instrument.Manufacturer + " - " + instrument.Manufacturer[0] + series.ToString(),
                    Power_Watt = power_watt,
                    Wire_Length_Metr = i % 2 == 0 ? 0 : 1.5f,
                    Rev_Per_Minute = i < 5 ? i * 1000 : i * 100,
                    Have_Wire = i % 2 == 0 ? false : true,
                    Count = new Random().Next(0, 15)
                });
                Thread.Sleep(1); // for correct random value
            }
            return drills;
        }
        internal List<Circular> GetCirculars(Instrument instrument)
        {
            circulars = new List<Circular>(50);
            int price = 0;
            int power_watt = 0;
            int series = 0;
            for (int i = 1; i < 50; i++)
            {
                price = new Random().Next(1500, 9990);
                power_watt = new Random().Next(400, 2000);
                power_watt = power_watt - (power_watt % 100);
                price = price - (price % 10);
                series = new Random().Next(400, 800) + i;
                circulars.Add(new Circular(instrument)
                {
                    InstrumentId = instrument.Id,
                    Series = series,
                    Discount = (i / 10) * 10,
                    Price = (i / 10) * 10 == 0 ? price : price - price / 100 * ((i % 10) * 10),
                    NameSeries = instrument.Manufacturer + " - " + instrument.Manufacturer[0] + series.ToString(),
                    Power_Watt = power_watt,
                    Wire_Length_Metr = i % 2 == 0 ? 0 : 1.5f,
                    Rev_Per_Minute = i < 5 ? i * 1000 : i * 100,
                    Have_Wire = i % 2 == 0 ? false : true,
                    Count = new Random().Next(0, 15)
                });
                Thread.Sleep(1); // for correct random value
            }
            return circulars;
        }
    }
}
