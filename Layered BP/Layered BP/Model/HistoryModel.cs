using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.PurchaseHistory
{
    class   History
    {
        public int UserID {  get; set; }
        public string ToyName {  get; set; }
        public float Price {  get; set; }
        public int Quantity { get; set; }
        public string Date { get; set; }

        public History() { }


        public History(int userID, string toyName, float price, int quantity, string date)
        {
            UserID = userID;
            ToyName = toyName;
            Price = price;
            Quantity = quantity;
            Date = date;
        }

        public override string ToString()
        {
            return $"{UserID} {ToyName} {Price} {Quantity} {Date}";
        }
    }
}
