using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace QazaqTehnologyForSite.Models.Laptops
{
    public class Processor
    {
        public Processor()
        {
            Laptops = new List<Laptop>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Laptop> Laptops { get; set; }
        // public int  NumberCores { get; set; } // Кол-во ядер
        // public int  NumberThreads { get; set; } // Кол-во потоков
        // public int  CoreFrequency { get; set; } // Частота ядер
        // public int  Heatdissipation { get; set; } // Тепловыделение
        // public bool  GraphicsCore { get; set; } // Графическое ядро
        //public virtual ICollection<Laptop> Laptops { get; set; } // Для другого МtoM
    }
}