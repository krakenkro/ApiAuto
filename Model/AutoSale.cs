using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiAuto.Model
{
    public class AutoSale
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public DateTime ProductionYear { get; set; }
        public int Price { get; set; }
        public string BodyType  { get; set; }
        public string EngineVolume { get; set; }
        public bool CustomsCleared { get; set; }
        public string Comment   { get; set; }
    }
}
