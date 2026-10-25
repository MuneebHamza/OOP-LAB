using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.Toy
{
    class toy
    {
        public string ToyID { get; set; }
        public string ToyName { get; set; }
        public string Category { get; set; }
        public string AgeGroup { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }

        public toy() { }

        public toy(string toyID, string toyName, string category, string ageGroup, float price, int stock)
        {
            ToyID = toyID;
            ToyName = toyName;
            Category = category;
            AgeGroup = ageGroup;
            Price = price;
            Stock = stock;
        }

        public override string ToString()
        {
            return $"{ToyID},{ToyName},{Category},{AgeGroup},{Price},{Stock}";
        }
    }
}
