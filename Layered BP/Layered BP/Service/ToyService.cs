using Layered_BP.Toy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.Service
{
    class ToyService
    {
        private readonly ToyRepository _toyRepository;
        public List<toy> toys;

        public ToyService()
        {
            _toyRepository = new ToyRepository();
            toys = _toyRepository.GetAll();
        }

        public toy FindToy(string name)
        {
            foreach (toy t in toys)
            {
                if (t.ToyName == name && t.ToyName != "") { return t; }    
            }
            return null;
        }

        public void AddToy(toy toy)
        {
            toys.Add(toy);
            _toyRepository.SaveAll(toys);
        }

        public void UpdateToy(toy toy, string name, string category, string ageGroup, float price, int stock)
        {
            toy.ToyName = name;
            toy.Category = category;
            toy.AgeGroup = ageGroup;
            toy.Price = price;
            toy.Stock = stock;
            _toyRepository.SaveAll(toys);
        }

        public void RemoveToy(toy toy)
        {
            toys.Remove(toy);
            _toyRepository.SaveAll(toys);
        }

        public void RestockToy(toy toy, int quantity)
        {
            toy.Stock += quantity;
            _toyRepository.SaveAll(toys);
        }

        public void SaveAll()
        {
            _toyRepository.SaveAll(toys);
        }

        public List<toy> GetAllToys()
        {
            return toys;
        }

        public List<toy> SortByStock()
        {
            List<toy> sorted = new List<toy>(toys);
            sorted.Sort((x, y) => x.Stock.CompareTo(y.Stock));
            return sorted;
        }

        public List<toy> SortByPrice()
        {
            List<toy> sorted = new List<toy>(toys);
            sorted.Sort((x, y) => x.Price.CompareTo(y.Price));
            return sorted;
        }

        public List<toy> FilterByCategory(string category)
        {
            List<toy> result = new List<toy>();
            foreach (toy t in toys)
            {
                if (t.ToyName != "" && t.Category == category)
                    result.Add(t);
            }
            return result;
        }


    }
}
