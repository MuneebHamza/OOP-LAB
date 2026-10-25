using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.Toy
{
    class ToyRepository
    {
        private readonly string _filepath = "toy.txt";
        public void save(toy toy)
        {
            using (StreamWriter writer = new StreamWriter(_filepath, true))
            {
                writer.WriteLine(toy.ToString());
            }
        }

        public void SaveAll(List<toy> toys)
        {
            using(StreamWriter writer = new StreamWriter(_filepath, false))
            {
                foreach (var toy in toys)
                {
                    writer.WriteLine(toy.ToString());
                }
            }
        }

        public string getField(string record, int field)
        {
            int commaCount = 1;
            string word = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    word = word + record[i];
                }
            }
            return word;
        }

        public List<toy> GetAll()
        {
            List<toy> toys = new List<toy>();

            if (!File.Exists(_filepath))
                return toys;

            using (StreamReader read = new StreamReader(_filepath))
            {
                string details;
                while ((details = read.ReadLine()) != null)
                {
                    // 1. Create a new Toy instance (using constructor or default values)
                    toy t = new toy("", "", "", "", 0, 0);

                    // 2. Assign values using your getField method
                    t.ToyID = getField(details, 1);
                    t.ToyName = getField(details, 2);
                    t.Category = getField(details, 3);
                    t.AgeGroup = getField(details, 4);
                    t.Price = float.Parse(getField(details, 5));
                    t.Stock = int.Parse(getField(details, 6));

                    
                    toys.Add(t);
                }
            }

            return toys;
        }

        public void clearAll()
        {
            File.WriteAllText(_filepath, string.Empty);
        }
    }
}