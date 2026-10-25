using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.Sales
{
    class SaleRepository
    {

        private readonly string _filepath = "sales.txt";
        public void save(Sale sale)
        {
            using (StreamWriter writer = new StreamWriter(_filepath, true))
            {
                writer.WriteLine(sale.ToString());
            }
        }

        public void SaveAll(List<Sale> sales)
        {
            using (StreamWriter writer = new StreamWriter(_filepath, false))
            {
                foreach (var Sale in sales)
                {
                    writer.WriteLine(Sale.ToString());
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

        public List<Sale> GetAll()
        {
            List<Sale> sales = new List<Sale>();

            if (!File.Exists(_filepath))
                return sales;

            using (StreamReader read = new StreamReader(_filepath))
            {
                string details;
                while ((details = read.ReadLine()) != null)
                {
                    Sale s = new Sale("", "", 0, 0);
                    s.SaleDate = getField(details, 1);
                    s.ToyName = getField(details, 2);
                    s.Quantity = int.Parse(getField(details, 3));
                    s.Amount = float.Parse(getField(details, 4));

                    sales.Add(s);
                }
            }

            return sales;
        }

        public void clearAll()
        {
            File.WriteAllText(_filepath, string.Empty);
        }
    }
}


