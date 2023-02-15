using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using QazaqTehnologyForSite.Models.Laptops;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace QazaqTehnologyForSite.Models
{
    public  class ApplicationContext : DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Laptop> Laptops { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Processor> Processors { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<RAMMemory> RamMemories { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<SSDMemory> SsdMemories { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Display> Displays { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Ports> Ports { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<WirelessConnection> WirelessConnections { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<NetworkController> NetworkControllers { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<SecurityLock> SecurityLocks { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<OperatingSystem> OperatingSystems { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Set> Sets { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Keyboard> Keyboards { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder
            //     .Entity<Laptop>()
            //     .HasMany(c => c.Processors)
            //     .WithMany(s => s.Laptops)
            //     .UsingEntity<LaptopProcessor>(
            //         j => j
            //             .HasOne(pt => pt.Processor)
            //             .WithMany(t => t.LaptopProcessors)
            //             .HasForeignKey(pt => pt.ProcessorId),
            //         j => j
            //             .HasOne(pt => pt.Laptop)
            //             .WithMany(p => p.LaptopProcessors)
            //             .HasForeignKey(pt => pt.LaptopId)
            //     );
        }

      
        
    }
}