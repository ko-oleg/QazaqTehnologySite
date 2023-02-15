using System.Collections.Generic;

namespace QazaqTehnologyForSite.Models.Laptops
{
    public class RAMMemory
    {
        public RAMMemory()
        {
            Laptops = new List<Laptop>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public ICollection<Laptop> Laptops { get; set; }
    }
}