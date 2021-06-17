using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice_7_WEB.Models
{
    public class Instrument
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public List<Drill> Drills { get; set; } = new List<Drill>();
        public List<Circular> Circulars { get; set; } = new List<Circular>();
    }
}
