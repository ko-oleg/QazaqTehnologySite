using System.Collections.Generic;

namespace QazaqTehnologyForSite.Models.Laptops
{
    public class Set
    {
        public Set()
        {
            Laptops = new List<Laptop>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Availability { get; set; }
        public ICollection<Laptop> Laptops { get; set; }
    }
}