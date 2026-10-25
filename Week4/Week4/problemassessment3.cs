/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace Week4
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer("muneeb", "sahiwal", 000000000);
            Product p1 = new Product("laptop", "digital", 3000);
            Product p2 = new Product("mobile", "digital", 5000);

            Console.WriteLine($"Name {c1.name}");
            c1.addProduct(p1);
            c1.addProduct(p2);

            foreach(Product p in c1.getAllProducts())
            {
                Console.WriteLine($"{p.name} tax: {p.CalculateTax()}"); 
            }

            Console.WriteLine($"TotalTax: {c1.calculateAllTax()}");

        }
    }

    class Customer
    {
        public string name;
        public string address;
        public int phoneNo;
        public List<Product> products;

        public Customer(string name, string address, int phoneNo)
        {
            this.name = name;
            this.address = address;
            this.phoneNo = phoneNo;
            products = new List<Product>();

        }
        public List<Product> getAllProducts()
        {
            return products;
        }

        public void addProduct(Product p)
        {
            products.Add(p);
        }
        //task 2
        public float calculateAllTax()
        {
            float totaltax = 0;
            foreach(Product p in products)
            {
                totaltax += p.CalculateTax();
            }

            return totaltax;
        }
    }

    class Product
    {
        public string name;
        public string category;
        public int price;

        public Product(string name , string category, int price)
        {
            this.name = name;
            this.category = category;
            this.price = price;
        }

        public float CalculateTax()
        {
            const float rate = 0.10f;
            return price * rate;
        }


    }
}*/
