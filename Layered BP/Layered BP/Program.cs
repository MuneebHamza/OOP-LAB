using Layered_BP.Service;
using Layered_BP.UI;

class Program
{
    static void Main(string[] args)
    {
        ToyService toyService = new ToyService();
        UserService userService = new UserService();
        SaleService saleService = new SaleService();
        HistoryService historyService = new HistoryService();

        ToyUI toyUI = new ToyUI(toyService);
        SaleUI saleUI = new SaleUI(saleService);
        HistoryUI historyUI = new HistoryUI(userService, historyService);
        CartUI cartUI = new CartUI(toyService, userService, saleService, historyService);
        UserUI userUI = new UserUI(userService, toyUI, saleUI, cartUI, historyUI);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("========================================================");
            Console.WriteLine("              Toy Shop Management System               ");
            Console.WriteLine("========================================================");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Customer");
            Console.WriteLine("3. Exit");
            Console.Write("Enter an option to choose: ");
            string option = Console.ReadLine();

            if (option == "1")
                userUI.AdminLogin();
            else if (option == "2")
                userUI.CustomerLogin();
            else if (option == "3")
                break;
            else
            {
                Console.WriteLine("Wrong option selected");
                Console.WriteLine("Press Enter to continue....");
                Console.ReadLine();
            }
        }

        Console.WriteLine("Thank you for using the Toy Shop Management System!");
    }


}