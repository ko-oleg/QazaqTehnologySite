namespace QazaqTehnologyForSite.Models.Laptops
{
    public class LaptopProcessor
    {
        public int LaptopId { get; set; }
        public Laptop Laptop { get; set; }
        public int ProcessorId { get; set; }
        public Processor Processor { get; set; }
    }
}