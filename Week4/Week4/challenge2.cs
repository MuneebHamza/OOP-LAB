/*using System;
using System.Collections.Generic;
using System.Text;

namespace Week4
{
    class Program
    {
        static void Main(string[] args)
        {

            member m1 = new member();
            int choice;

            do
            {
                Console.WriteLine("1. Show Member Details");
                Console.WriteLine("2. Modify/Set Person's Name");
                Console.WriteLine("3. Update/Modify Money in Bank");
                Console.WriteLine("4. Simulate Buying a Book");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice (1-5): ");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    m1.ShowMemberDetails();
                }
                else if (choice == 2)
                {
                    Console.Write("Enter new name: ");
                    string newName = Console.ReadLine();
                    m1.setName(newName);
                    Console.WriteLine("Name updated successfully!");
                }
                else if (choice == 3)
                {
                    Console.Write("Enter amount to add from bank: ");
                    float amount = float.Parse(Console.ReadLine());
                    m1.addmoney(amount);
                    Console.WriteLine($"Bank balance updated. Current balance: ${m1.moneyInBank}");
                }
                else if (choice == 4)
                {
                    Console.Write("Enter Book Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter Book Price: ");
                    float price = float.Parse(Console.ReadLine());

                    List<string> authors = new List<string>();

                    Book boughtBook = new Book(title,authors, 1, "Generic Publisher" , "2113131231" ,price, 12);
                    m1.buybook(boughtBook);
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Exiting program. Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid choice! Please choose between 1 and 5.");
                }

            } while (choice != 5);
        }
    }

    class member
    {
        public string name;
        public string ID;
        List<Book> booksbought;
        public int no_books_bought;
        public float moneyInBank;
        public float moneySpent;

        public member()
        {
            name = "";
            ID = "";
            booksbought = new List<Book>();
            no_books_bought = 0;
            moneyInBank = 0.0f;
            moneySpent = 0.0f;

        }

        public member(string name, string ID, List<Book> booksbought, int no_books_bought, float moneyInBank, float moneySpent)
        {
            this.name = name;
            this.ID = ID;
            this.booksbought = booksbought;
            this.no_books_bought = no_books_bought;
            this.moneyInBank = moneyInBank;
            this.moneySpent = moneySpent;

        }


        public void setName(string newName)
        {
            name = newName;
        }
        public string getName()
        {
            return name;
        }

        public void buybook(Book book)
        {
            booksbought.Add(book);
            moneySpent += book.price;
            moneyInBank -= book.price;
        }

        public void ShowBookbought()
        {
            Console.WriteLine(booksbought.Count);
            Console.WriteLine(moneySpent);
        }

        public void addmoney(float money)
        {
            moneyInBank += money;
        }

        public void ShowMemberDetails()
        {
            getName();
            Console.WriteLine("Member ID: " + ID);
            Console.WriteLine("Money in Bank: $" + moneyInBank);
            ShowBookbought();

            if (booksbought.Count > 0)
            {
                Console.WriteLine("Books Purchased List:");
                for (int i = 0; i < booksbought.Count; i++)
                {
                    Console.WriteLine($"{booksbought[i].title},, {booksbought[i].price}");
                }
            }


        }

       
    }
    class Book
    {
        public string title;
        public List<string> authors;
        public int numAuthors;
        public string publisher;
        public string isbn;
        public float price;
        public int stock;

        public Book(string title, List<string> authors, int numAuthors, string publisher, string isbn, float price, int stock)
        {
            this.title = title;
            this.numAuthors = numAuthors;
            this.authors = authors;
            this.publisher = publisher;
            this.isbn = isbn;
            this.price = price;
            this.stock = stock;
        }
    }
}*/

