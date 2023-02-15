using System.Collections.Generic;

namespace QazaqTehnologyForSite.Models.Laptops
{
    public class OperatingSystem
    {
        public OperatingSystem()
        {
            Laptops = new List<Laptop>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string More { get; set; }
        public ICollection<Laptop> Laptops { get; set; }
    }
}