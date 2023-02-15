using System.Collections.Generic;

namespace QazaqTehnologyForSite.Models.Laptops
{
    public class Display
    {
        public Display()
        {
            Laptops = new List<Laptop>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Resolution { get; set; }
        public string Diagonal { get; set; }
        public bool AntiglareCoating { get; set; }
        public ICollection<Laptop> Laptops { get; set; }
    }
}