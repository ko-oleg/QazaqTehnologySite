using System.Globalization;

namespace QazaqTehnologyForSite.Models.Laptops
{
    public class Processor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int  NumberCores { get; set; } // Кол-во ядер
        public int  NumberThreads { get; set; } // Кол-во потоков
        public int  CoreFrequency { get; set; } // Частота ядер
        public int  Heatdissipation { get; set; } // Тепловыделение
        public bool  GraphicsCore { get; set; } // Графическое ядро
    }
}