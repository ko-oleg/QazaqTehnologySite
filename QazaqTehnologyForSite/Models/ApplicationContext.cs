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
        // public DbSet<RAMMemory> RamMemories { get; set; }
        // public DbSet<SSDMemory> SsdMemories { get; set; }
        // public DbSet<Display> Displays { get; set; }
        // public DbSet<Ports> Ports { get; set; }
        // public DbSet<WirelessConnection> WirelessConnections { get; set; }
        // public DbSet<NetworkController> NetworkControllers { get; set; }
        // public DbSet<SecurityLock> SecurityLocks { get; set; }
        // public DbSet<OperatingSystem> OperatingSystems { get; set; }
        // public DbSet<Set> Sets { get; set; }
        // public DbSet<Keyboard> Keyboards { get; set; }
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