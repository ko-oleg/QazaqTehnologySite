using System.Collections.Generic;
using QazaqTehnologyForSite.Models.Interfaces;

namespace QazaqTehnologyForSite.Models.Laptops
{
    public class Laptop 
    {
        public Laptop()
        {
            Processors = new List<Processor>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Processor> Processors{ get; set; }
        // public Processor Processor { get; set; }
        // public RAMMemory RamMemory { get; set; }
        // public SSDMemory SsdMemory { get; set; }
        // public Display Display { get; set; }
        // public Ports Ports { get; set; }
        // public WirelessConnection WirelessConnection { get; set; }
        // public NetworkController NetworkController { get; set; }
        // public SecurityLock SecurityLock { get; set; }
        // public OperatingSystem OperatingSystem { get; set; }
        // public Set Set { get; set; }
        // public Keyboard Keyboard { get; set; }
        
    }
    
}