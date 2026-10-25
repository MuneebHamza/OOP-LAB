using Layered_BP.Service;
using Layered_BP.Toy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.UI
{
    class ToyUI
    {
        private readonly ToyService _toyService;

        public ToyUI(ToyService toyService)
        {
            _toyService = toyService;
        }

        // ===================for admin

        public void AddProductUI()
        {
            Console.Clear();
            Console.Write("Enter Toy ID: ");
            string id = Console.ReadLine();
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Category: ");
            string cat = Console.ReadLine();
            Console.Write("Enter Age Group: ");
            string age = Console.ReadLine();
            float price = inputhelper.ReadFloat("Enter Price: ");
            int stock = inputhelper.ReadInt("Enter Stock: ");

            toy toy = new toy(id, name, cat, age, price, stock);
            _toyService.AddToy(toy);
            Console.WriteLine("Product added successfully!");
        }

        public void UpdateProductUI()
        {
            Console.Clear();
            Console.Write("Enter Toy name to update: ");
            string searchname = Console.ReadLine();
            toy toy = _toyService.FindToy(searchname);
            if (toy == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }
            Console.WriteLine("Old: Name=" + toy.ToyName + " Category=" + toy.Category + " Price=" + toy.Price + " Stock=" + toy.Stock);
            Console.Write("Enter new Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter new Category: ");
            string cat = Console.ReadLine();
            Console.Write("Enter new Age Group: ");
            string age = Console.ReadLine();
            float price = inputhelper.ReadFloat("Enter new Price: ");
            int stock = inputhelper.ReadInt("Enter new Stock: ");

            _toyService.UpdateToy(toy, name, cat, age, price, stock);
            Console.WriteLine("Updated successfully!");
        }

        public void RemoveProductUI()
        {
            Console.Clear();
            Console.Write("Enter Toy name to delete: ");
            string searchname = Console.ReadLine();
            toy toy = _toyService.FindToy(searchname);
            if (toy == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }
            _toyService.RemoveToy(toy);
            Console.WriteLine(searchname + " removed successfully!");
        }

        public void RestockUI()
        {
            Console.Clear();
            Console.Write("Enter Toy Name to restock: ");
            string searchname = Console.ReadLine();
            toy toy = _toyService.FindToy(searchname);
            if (toy == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }
            Console.WriteLine("Current stock: " + toy.Stock);
            int qty = inputhelper.ReadInt("Enter quantity to add: ");
            _toyService.RestockToy(toy, qty);
            Console.WriteLine("New stock: " + toy.Stock);
        }

        public void SortByStockUI()
        {
            Console.Clear();
            List<toy> sorted = _toyService.SortByStock();
            Console.WriteLine("Name \t\t Category \t Price \t Stock");
            foreach (toy t in sorted)
            {
                if (t.ToyName != "")
                    Console.WriteLine(t.ToyName + "\t\t" + t.Category + "\t\t" + t.Price + "\t" + t.Stock);
            }
        }

        // ================== for customer

        public void ViewAllProductsUI()
        {
            Console.Clear();
            Console.WriteLine("ID \t Name \t\t\t Category \t Age \t Price \t Stock");
            foreach (toy t in _toyService.GetAllToys())
            {
                if (t.ToyName != "")
                    Console.WriteLine(t.ToyID + "\t" + t.ToyName + "\t\t" + t.Category + "\t\t" + t.AgeGroup + "\t" + t.Price + "\t" + t.Stock);
            }
        }

        public void SearchByNameUI()
        {
            Console.Clear();
            Console.Write("Enter toy name to search: ");
            string searchname = Console.ReadLine();
            toy toy = _toyService.FindToy(searchname);
            if (toy == null)
            {
                Console.WriteLine("Toy not found.");
                return;
            }
            Console.WriteLine("Name \t\t Category \t Age \t Price \t Stock");
            Console.WriteLine(toy.ToyName + "\t\t" + toy.Category + "\t\t" + toy.AgeGroup + "\t" + toy.Price + "\t" + toy.Stock);
        }

        public void SortByPriceUI()
        {
            Console.Clear();
            List<toy> sorted = _toyService.SortByPrice();
            Console.WriteLine("Name \t\t Category \t Price \t Stock");
            foreach (toy t in sorted)
            {
                if (t.ToyName != "")
                    Console.WriteLine(t.ToyName + "\t\t" + t.Category + "\t\t" + t.Price + "\t" + t.Stock);
            }
        }

        public void FilterByCategoryUI()
        {
            Console.Clear();
            Console.WriteLine("Categories: Blocks, Doll, Vehicle, Puzzle, Action, Plush, Pretend, Outdoor, Board");
            Console.Write("Enter category: ");
            string cat = Console.ReadLine();
            List<toy> result = _toyService.FilterByCategory(cat);
            if (result.Count == 0)
            {
                Console.WriteLine("No toys found in this category.");
                return;
            }
            Console.WriteLine("Name \t\t Age \t Price \t Stock");
            foreach (toy t in result)
                Console.WriteLine(t.ToyName + "\t\t" + t.AgeGroup + "\t" + t.Price + "\t" + t.Stock);
        }
    }
}

