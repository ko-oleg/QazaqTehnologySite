using System.Collections.Generic;

namespace QazaqTehnologyForSite.Models.Laptops
{
    public class Laptop 
    {
        public Laptop()
        {
            Processors = new List<Processor>();
            RamMemory = new List<RAMMemory>();
            SsdMemory = new List<SSDMemory>();
            Display = new List<Display>();
            Ports = new List<Ports>();
            WirelessConnection = new List<WirelessConnection>();
            NetworkController = new List<NetworkController>();
            SecurityLock = new List<SecurityLock>();
            OperatingSystem = new List<OperatingSystem>();
            Set = new List<Set>();
            Keyboard = new List<Keyboard>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Processor> Processors{ get; set; }
        public ICollection<RAMMemory>  RamMemory { get; set; }
        public ICollection<SSDMemory>  SsdMemory { get; set; }
        public ICollection<Display>  Display { get; set; }
        public ICollection<Ports> Ports { get; set; }
        public ICollection<WirelessConnection> WirelessConnection { get; set; }
        public ICollection<NetworkController> NetworkController { get; set; }
        public ICollection<SecurityLock> SecurityLock { get; set; }
        public ICollection<OperatingSystem> OperatingSystem { get; set; }
        public ICollection<Set> Set { get; set; }
        public ICollection<Keyboard> Keyboard { get; set; }
        
    }
    
}