using System;
using System.Collections.Generic;

namespace QazaqTehnologyForSite.Models.Laptops
{
    public class Keyboard
    {
        public Keyboard()
        {
            Laptops = new List<Laptop>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public KeyboardLanguages Language { get; set; }
        public ICollection<Laptop> Laptops { get; set; }

        public enum KeyboardLanguages
        {
            KazakhLanguage = 1,
            RussianLanguage,
            EnglishLanguage,
        }
    }
}