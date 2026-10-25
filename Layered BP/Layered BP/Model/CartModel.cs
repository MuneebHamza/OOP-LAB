using Layered_BP;
using Layered_BP.Toy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.CartI
{
    class CartItem
    {
        public toy t { get; set; }
        public int Quantity { get; set; }

        public CartItem() { }

        public CartItem(toy toy, int quantity)
        {
            t = toy;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{t} {Quantity}";
        }
    }
}
