using Microsoft.EntityFrameworkCore;
using QazaqTehnologyForSite.Models.Laptops;

namespace QazaqTehnologyForSite.Models.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<RAMMemory> RamMemories { get; set; }
        public DbSet<SSDMemory> SsdMemories { get; set; }
        public DbSet<Display> Displays { get; set; }
        public DbSet<Ports> Ports { get; set; }
        public DbSet<WirelessConnection> WirelessConnections { get; set; }
        public DbSet<NetworkController> NetworkControllers { get; set; }
        public DbSet<SecurityLock> SecurityLocks { get; set; }
        public DbSet<OperatingSystem> OperatingSystems { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Keyboard> Keyboards { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}