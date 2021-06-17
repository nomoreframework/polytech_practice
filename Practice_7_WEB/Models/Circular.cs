
namespace Practice_7_WEB.Models
{
    public class Circular : ElectricInstrument
    {
        public Circular() { }
        public Circular(Instrument instrument):base(instrument)
        {
            this.Type = "УШМ";
        }
    }
}
