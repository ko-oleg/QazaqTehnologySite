using System.Collections.Generic;

namespace QazaqTehnologyForSite.Models.Laptops
{
    public class SSDMemory
    {
        public SSDMemory()
        {
            Laptops = new List<Laptop>(); }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity{ get; set; }
        public string Type{ get; set; }
        public string ReadingSpeed{ get; set; }
        public string WriteSpeed{ get; set; }
        public string OperatingTime{ get; set; }
        public string InterfaceAndProtocol{ get; set; }
        public ICollection<Laptop> Laptops { get; set; }
    }
}