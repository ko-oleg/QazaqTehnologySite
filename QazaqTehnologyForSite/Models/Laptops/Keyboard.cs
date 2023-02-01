using System;

namespace QazaqTehnologyForSite.Models.Laptops
{
    public class Keyboard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public KeyboardLanguages Language { get; set; }

        public enum KeyboardLanguages
        {
            KazakhLanguage = 1,
            RussianLanguage,
            EnglishLanguage,
        }
    }
}