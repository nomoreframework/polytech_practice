using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_7_WEB.Models.Interfaces
{
    interface I_Instrument
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }
        public int Power_Watt { get; set; }
        public float Wire_Length_Metr { get; set; }
        public int Rev_Per_Minute { get; set; }
        public bool Have_Wire { get; set; }
    }
}
