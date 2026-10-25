using Layered_BP;
using Layered_BP.CartI;
using Layered_BP.PurchaseHistory;
using Layered_BP.Sales;
using Layered_BP.Service;
using Layered_BP.Toy;
using Layered_BP.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.UI
{
    class CartUI
    {
        private readonly ToyService _toyService;
        private readonly UserService _userService;
        private readonly SaleService _saleService;
        private readonly HistoryService _historyService;

        private List<CartItem> _cart = new List<CartItem>();

        public CartUI(ToyService toyService, UserService customerService,
                          SaleService saleService, HistoryService historyService)
        {
            _toyService = toyService;
            _userService = customerService;
            _saleService = saleService;
            _historyService = historyService;
        }

        // =================== called when a customer logs in so the cart starts empty
        public void ClearCart()
        {
            _cart.Clear();
        }

        public void AddToCartUI()
        {
            Console.Clear();
            Console.Write("Enter toy name to add to cart: ");
            string searchname = Console.ReadLine();
            toy toy = _toyService.FindToy(searchname);
            if (toy == null)
            {
                Console.WriteLine("Toy not found.");
                return;
            }
            if (toy.Stock == 0)
            {
                Console.WriteLine("Sorry, This toy is out of stock.");
                return;
            }
            Console.WriteLine("Price: Rs." + toy.Price + "\t Stock available: " + toy.Stock);
            int quantity = inputhelper.ReadInt("Enter quantity: ");
            if (quantity <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }
            if (quantity > toy.Stock)
            {
                Console.WriteLine("Not enough stock. Max available: " + toy.Stock);
                return;
            }

            // check if already in cart
            bool already = false;
            foreach (CartItem item in _cart)
            {
                if (item.t.ToyName == toy.ToyName)
                {
                    if (item.Quantity + quantity > toy.Stock)
                        Console.WriteLine("Total in cart would exceed stock!");
                    else
                    {
                        item.Quantity += quantity;
                        Console.WriteLine("Updated cart quantity!");
                    }
                    already = true;
                    break;
                }
            }
            if (already == false)
            {
                _cart.Add(new CartItem(toy, quantity));
                Console.WriteLine(quantity + "x " + toy.ToyName + " added to cart!");
            }
        }

        public void ViewCartUI()
        {
            Console.Clear();
            if (_cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                return;
            }

            Console.WriteLine("No. \t Name \t\t\t Qty \t Price \t Subtotal");
            float carttotal = 0;
            for (int i = 0; i < _cart.Count; i++)
            {
                float sub = _cart[i].t.Price * _cart[i].Quantity;
                carttotal += sub;
                Console.WriteLine((i + 1) + "\t" + _cart[i].t.ToyName + "\t\t" + _cart[i].Quantity + "\t" + _cart[i].t.Price + "\t" + sub);
            }
            Console.WriteLine("Cart Total: Rs." + carttotal);
            int removenum = inputhelper.ReadInt("Enter item number to remove (0 to keep all): ");
            if (removenum > 0 && removenum <= _cart.Count)
            {
                _cart.RemoveAt(removenum - 1);
                Console.WriteLine("Item removed from cart.");
            }
        }

        public void CheckoutUI(User loggedInUser)
        {
            Console.Clear();
            if (_cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty. Nothing to checkout.");
                return;
            }

            float subtotal = 0;
            foreach (CartItem item in _cart)
                subtotal += item.t.Price * item.Quantity;

            float memberdisc = 0;
            if (loggedInUser.Membership == "Gold")
                memberdisc = subtotal * 0.10f;
            else if (loggedInUser.Membership == "Silver")
                memberdisc = subtotal * 0.05f;

            float afterDiscount = subtotal - memberdisc;
            float tax = afterDiscount * 0.05f;
            float grandtotal = afterDiscount + tax;

            Console.WriteLine("Subtotal: Rs." + subtotal);
            Console.WriteLine("Membership Discount: Rs." + memberdisc);
            Console.WriteLine("Tax (5%): Rs." + tax);
            Console.WriteLine("Grand Total: Rs." + grandtotal);
            Console.Write("Enter today's date (YYYY-MM-DD): ");
            string today = Console.ReadLine();
            Console.Write("Confirm purchase? (yes/no): ");
            string confirm = Console.ReadLine();

            if (confirm == "yes")
            {
                foreach (CartItem item in _cart)
                {
                    // reduce stock
                    item.t.Stock -= item.Quantity;

                    // add to history
                    _historyService.AddRecord(new History(loggedInUser.UserID, item.t.ToyName, item.t.Price, item.Quantity, today));

                    // add to sales
                    _saleService.AddSale(new Sale(today, item.t.ToyName, item.Quantity, item.t.Price * item.Quantity));
                }

                // update membership
                _userService.UpdateMembership(loggedInUser, grandtotal);

                // save toy stock changes
                _toyService.SaveAll();

                _cart.Clear();
                Console.WriteLine("Purchase successful! Thank you, " + loggedInUser.UserName + "!");
            }
            else
            {
                Console.WriteLine("Checkout cancelled.");
            }
        }
    }
}
