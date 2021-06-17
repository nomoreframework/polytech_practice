
namespace Practice_7_WEB.Models
{
    public class Drill : ElectricInstrument
    {
        public Drill() { }
        public Drill(Instrument instrument):base(instrument)
        {
            this.Type = "Дрель";
        }
    }
}
