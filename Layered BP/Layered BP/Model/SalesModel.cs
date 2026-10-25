using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.Sales
{
    class Sale
    {
        public string SaleDate {  get; set; }
        public string ToyName { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }

        public Sale() { }

        public Sale(string saleDate, string toyName, int quantity, float amount)
        {
            SaleDate = saleDate;
            ToyName = toyName;
            Quantity = quantity;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{SaleDate},{ToyName},{Quantity},{Amount}";
        }
    }
}
