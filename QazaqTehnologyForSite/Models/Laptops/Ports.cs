using System.Collections.Generic;
using System.Globalization;

namespace QazaqTehnologyForSite.Models.Laptops
{
    public class Ports
    {
        public Ports()
        {
            Laptops = new List<Laptop>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string More { get; set; }
        public ICollection<Laptop> Laptops { get; set; }
    }
}