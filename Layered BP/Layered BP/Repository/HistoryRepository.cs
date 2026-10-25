using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.PurchaseHistory
{
    class HistoryRepository
    {

        private readonly string _filepath = "history.txt";
        public void save(History history)
        {
            using (StreamWriter writer = new StreamWriter(_filepath, true))
            {
                writer.WriteLine(history.ToString());
            }
        }

        public void SaveAll(List<History> histories)
        {
            using (StreamWriter writer = new StreamWriter(_filepath, false))
            {
                foreach (var History in histories)
                {
                    writer.WriteLine(History.ToString());
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

        public List<History> GetAll()
        {
            List<History> histories = new List<History>();

            if (!File.Exists(_filepath))
                return histories;

            using (StreamReader read = new StreamReader(_filepath))
            {
                string details;
                while ((details = read.ReadLine()) != null)
                {
                    History h = new History(0, "", 0, 0, "");
                    h.UserID = int.Parse(getField(details, 1));
                    h.ToyName = getField(details, 2);
                    h.Price = float.Parse(getField(details, 3));
                    h.Quantity = int.Parse(getField(details, 4));
                    h.Date = getField(details, 5);

                    histories.Add(h);
                }
            }

            return histories;
        }

        public void clearAll()
        {
            File.WriteAllText(_filepath, string.Empty);
        }
    }
}

