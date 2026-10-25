using Layered_BP.Service;
using Layered_BP.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.UI
{
    class UserUI
    {
        private readonly UserService _userService;
        private readonly ToyUI _toyUI;
        private readonly SaleUI _saleUI;
        private readonly CartUI _cartUI;
        private readonly HistoryUI _historyUI;

        public UserUI(UserService userService, ToyUI toyUI, SaleUI saleUI,
                          CartUI cartUI, HistoryUI historyUI)
        {
            _userService = userService;
            _toyUI = toyUI;
            _saleUI = saleUI;
            _cartUI = cartUI;
            _historyUI = historyUI;
        }

        // ==================== admin
        public void AdminLogin()
        {
            for (int attempt = 0; attempt < 3; attempt++)
            {
                Console.Clear();
                Console.WriteLine("Admin Login : Attempt " + (attempt + 1));
                Console.Write("Username: ");
                string uname = Console.ReadLine();
                Console.Write("Password: ");
                string upass = Console.ReadLine();
                if ( uname == "admin" && upass == "123")
                {
                    Console.WriteLine("Login Successful!");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    ShowAdminMenu();
                    return;
                }

                if (attempt < 2)
                    Console.WriteLine("Invalid username or password.");
                else
                    Console.WriteLine("3 failed attempts. Access denied.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        // =================== customer
        public void CustomerLogin()
        {
            Console.Clear();
            Console.Write("Enter your name: ");
            string cname = Console.ReadLine();
            User loggedInUser = _userService.FindUser(cname);

            if (loggedInUser == null)
            {
                Console.Write("Name not found. Register as new customer? (yes/no): ");
                string reg = Console.ReadLine();
                if (reg == "yes")
                {
                    loggedInUser = new User(_userService.Users.Count + 1, cname,"None", 0);
                    _userService.AddCustomer(loggedInUser);
                    Console.WriteLine("Account created! Welcome, " + cname + "!");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Press Enter to return...");
                    Console.ReadLine();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Welcome, " + loggedInUser.UserName + "! Membership: " + loggedInUser.Membership);
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            ShowCustomerMenu(loggedInUser);
        }

        // ── Admin menu ────────────────────────────────────────
        public void ShowAdminMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("           ADMIN PANEL                ");
                Console.WriteLine("1.  Add New Product");
                Console.WriteLine("2.  Update Product Details");
                Console.WriteLine("3.  Remove Product");
                Console.WriteLine("4.  Restock Inventory");
                Console.WriteLine("5.  Sort Inventory by Stock");
                Console.WriteLine("6.  View Total Sales History");
                Console.WriteLine("7.  Sort Sales by Revenue");
                Console.WriteLine("8.  Search Customer History");
                Console.WriteLine("9.  User Management");
                Console.WriteLine("10. Logout");
                Console.Write("Choose Option: ");
                string option = Console.ReadLine();

                if (option == "1")
                    _toyUI.AddProductUI();
                else if (option == "2")
                    _toyUI.UpdateProductUI();
                else if (option == "3")
                    _toyUI.RemoveProductUI();
                else if (option == "4")
                    _toyUI.RestockUI();
                else if (option == "5")
                    _toyUI.SortByStockUI();
                else if (option == "6")
                    _saleUI.ViewSalesUI();
                else if (option == "7")
                    _saleUI.SortSalesByRevenueUI();
                else if (option == "8")
                    _historyUI.SearchCustomerHistoryUI();
                else if (option == "9")
                    ViewAllUsersUI();
                else if (option == "10")
                    break;
                else
                    Console.WriteLine("Invalid option. Try again.");

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            Console.WriteLine("Logged out. Press Enter...");
            Console.ReadLine();
        }

        // ── Customer menu ─────────────────────────────────────
        public void ShowCustomerMenu(User loggedInUser)
        {
            _cartUI.ClearCart();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("  CUSTOMER MENU : " + loggedInUser.UserName);
                Console.WriteLine("1.  View All Products");
                Console.WriteLine("2.  Search by Name");
                Console.WriteLine("3.  Sort by Price (Ascending)");
                Console.WriteLine("4.  Filter by Category");
                Console.WriteLine("5.  Add to Cart");
                Console.WriteLine("6.  View / Remove from Cart");
                Console.WriteLine("7.  View My Purchase History");
                Console.WriteLine("8.  Membership Status");
                Console.WriteLine("9.  Checkout");
                Console.WriteLine("10. Logout");
                Console.Write("Choose Option: ");
                string option = Console.ReadLine();

                if (option == "1")
                    _toyUI.ViewAllProductsUI();
                else if (option == "2")
                    _toyUI.SearchByNameUI();
                else if (option == "3")
                    _toyUI.SortByPriceUI();
                else if (option == "4")
                    _toyUI.FilterByCategoryUI();
                else if (option == "5")
                    _cartUI.AddToCartUI();
                else if (option == "6")
                    _cartUI.ViewCartUI();
                else if (option == "7")
                    _historyUI.ViewPurchaseHistoryUI(loggedInUser);
                else if (option == "8")
                    ViewMembershipStatusUI(loggedInUser);
                else if (option == "9")
                    _cartUI.CheckoutUI(loggedInUser);
                else if (option == "10")
                {
                    Console.WriteLine("Logged out. Goodbye, " + loggedInUser.UserName + "!");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                }
                else
                    Console.WriteLine("Wrong option selected.");

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        // ── Screens ───────────────────────────────────────────

        public void ViewMembershipStatusUI(User loggedInUser)
        {
            Console.Clear();
            Console.WriteLine("Name: " + loggedInUser.UserName);
            Console.WriteLine("Total Spent: Rs." + loggedInUser.TotalSpent);
            Console.WriteLine("Membership: " + loggedInUser.Membership);
            Console.WriteLine();
            if (loggedInUser.Membership == "Gold")
                Console.WriteLine("You are a Gold member! Enjoy 10% discount on all purchases.");
            else if (loggedInUser.Membership == "Silver")
                Console.WriteLine("You are a Silver member! Spend Rs.15000 total to reach Gold.");
            else
            {
                Console.WriteLine("Spend Rs.8000 total to reach Silver membership.");
                Console.WriteLine("Spend Rs.15000 total to reach Gold membership.");
            }
        }

        // admin screen (User Management)
        public void ViewAllUsersUI()
        {
            Console.Clear();
            Console.WriteLine("ID \t Name \t\t Role \t\t Membership \t Total Spent");
            foreach (User u in _userService.GetAllUsers())
                Console.WriteLine(u.UserID + "\t" + u.UserName + "\t\t" + u.Membership + "\t\t" + u.TotalSpent);
        }
    }
}
