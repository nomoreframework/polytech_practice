using System.ComponentModel.DataAnnotations.Schema;
using Practice_7_WEB.Models.Interfaces;
namespace Practice_7_WEB.Models
{
    public class ElectricInstrument : I_Instrument
    {
        public ElectricInstrument() { }
        public ElectricInstrument(Instrument instrument)
        {
            Instrument = instrument;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int InstrumentId { get; set; }
        [ForeignKey("InstrumentId")]
        public Instrument Instrument { get; set; }
        public int Series { get; set; }
        public string NameSeries { get; set; }
        public string Type { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }
        public int Power_Watt { get; set; }
        public float Wire_Length_Metr { get; set; }
        public int Rev_Per_Minute { get; set; }
        public int Count { get; set; }
        public bool Have_Wire { get; set; }
    }
}
