using Layered_BP.PurchaseHistory;
using Layered_BP.Service;
using Layered_BP.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.UI
{
    class HistoryUI
    {
        private readonly UserService _userService;
        private readonly HistoryService _historyService;

        public HistoryUI(UserService userservice, HistoryService historyService)
        {
            _userService = userservice;
            _historyService = historyService;
        }

        // ============== admin
        public void SearchCustomerHistoryUI()
        {
            Console.Clear();
            Console.Write("Enter customer name: ");
            string name = Console.ReadLine();
            User customer = _userService.FindUser(name);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }
            Console.WriteLine("Purchase history for " + name + ":");
            Console.WriteLine("Date \t\t Toy \t\t Qty \t Amount");
            List<History> records = _historyService.GetByUser(customer.UserID);
            if (records.Count == 0)
            {
                Console.WriteLine("No purchase history found.");
                return;
            }
            foreach (History h in records)
                Console.WriteLine(h.Date + "\t" + h.ToyName + "\t\t" + h.Quantity + "\t" + h.Price * h.Quantity);
        }

        // ================================ customer
        public void ViewPurchaseHistoryUI(User loggedInUser)
        {
            Console.Clear();
            Console.WriteLine("Purchase History for " + loggedInUser.UserName);
            Console.WriteLine("Date \t\t Toy \t\t Qty \t Amount");
            List<History> records = _historyService.GetByUser(loggedInUser.UserID);
            if (records.Count == 0)
            {
                Console.WriteLine("No purchase history yet.");
                return;
            }
            foreach (var h in records)
            {
                Console.WriteLine(h.Date + "\t" + h.ToyName + "\t\t" + h.Quantity + "\t" + h.Price * h.Quantity);
            }
        }
    }
}
