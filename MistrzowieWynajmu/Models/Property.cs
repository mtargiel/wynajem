using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistrzowieWynajmu.Models
{
    public class Property
    {
        public int IdProperty { get; set; }
        public int NumberOfRooms { get; set; }
        public double Area { get; set; }
        public PropertyType Type { get; set; }
        public string Localization { get; set; }
        public int Rooms { get; set; }
        public bool Washer { get; set; }
        public bool Refrigerator { get; set; }
        public bool Iron { get; set; }


        public virtual Owner Owner { get; set; }
        public virtual Address Address { get; set; }
    }
}
