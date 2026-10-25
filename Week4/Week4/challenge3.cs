/*using System;
using System.Collections.Generic;

namespace Week4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> inventory = new List<Book>();
            List<Member> members = new List<Member>();

            float totalSales = 0.0f;
            float totalMembershipFees = 0.0f;
            int choice;

            do
            {
                Console.WriteLine("\n--- Bookstore Management Menu ---");
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. Search for a Book by Title");
                Console.WriteLine("3. Search for a Book by ISBN");
                Console.WriteLine("4. Update Stock of a Book");
                Console.WriteLine("5. Add a Member");
                Console.WriteLine("6. Search for a Member by Name or ID");
                Console.WriteLine("7. Update Member Information");
                Console.WriteLine("8. Purchase a Book");
                Console.WriteLine("9. Display Total Sales and Membership Stats");
                Console.WriteLine("10. Exit");
                Console.Write("Enter your choice (1-10): ");

                 choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Write("Enter Book Title: ");
                    string title = Console.ReadLine();

                    Console.Write("How many authors? ");
                    int numAuth = int.Parse(Console.ReadLine());
                    List<string> authors = new List<string>();
                    for (int i = 0; i < numAuth; i++)
                    {
                        Console.Write($"Enter author {i + 1}: ");
                        authors.Add(Console.ReadLine());
                    }

                    Console.Write("Enter Publisher: ");
                    string publisher = Console.ReadLine();

                    Console.Write("Enter ISBN: ");
                    string isbn = Console.ReadLine();

                    Console.Write("Enter Price: ");
                    float price = float.Parse(Console.ReadLine());

                    Console.Write("Enter Stock: ");
                    int stock = int.Parse(Console.ReadLine());

                    Console.Write("Enter Year of Publication: ");
                    int year = int.Parse(Console.ReadLine());

                    Book newBook = new Book(title, authors, numAuth, publisher, isbn, price, stock, year);
                    inventory.Add(newBook); 
                    Console.WriteLine("Book added to inventory successfully!");
                }
                else if (choice == 2)
                {
                    Console.Write("Enter book title to search: ");
                    string searchTitle = Console.ReadLine();
                    bool found = false;

                    foreach (Book b in inventory)
                    {
                        if (searchTitle == b.title)
                        {
                            Console.WriteLine("Book Found:");
                            b.ShowBookDetails();
                            found = true;
                        }
                    }
                    if (!found) Console.WriteLine("Book not found.");
                }
                else if (choice == 3)
                {
                    Console.Write("Enter ISBN to search: "); 
                    string searchIsbn = Console.ReadLine();
                    bool found = false;

                    foreach (Book b in inventory)
                    {
                        if (searchIsbn == b.isbn)
                        {
                            Console.WriteLine("\nBook Found:"); 
                            b.ShowBookDetails();
                            found = true;
                            break;
                        }
                    }
                    if (!found) Console.WriteLine("Book not found.");
                }
                else if (choice == 4)
                {
                    Console.Write("Enter title or ISBN of the book to update stock: "); 
                    string query = Console.ReadLine();
                    Book targetBook = null;

                    foreach (Book b in inventory)
                    {
                        if (query == b.title || query == b.isbn)
                        {
                            targetBook = b;
                            break;
                        }
                    }

                    if (targetBook != null)
                    {
                        Console.WriteLine($"Current stock: {targetBook.stock}");
                        Console.Write("Do you want to (1) Increase or (2) Decrease stock? Enter 1 or 2: ");
                        int opt = int.Parse(Console.ReadLine());
                        Console.Write("Enter quantity: ");
                        int qty = int.Parse(Console.ReadLine());

                        if (opt == 1) targetBook.stock += qty;
                        else if (opt == 2) targetBook.stock -= qty;

                        Console.WriteLine($"Stock updated successfully! New stock: {targetBook.stock}");
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                }
                else if (choice == 5)
                {
                    Console.Write("Enter Member Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Member ID: ");
                    string id = Console.ReadLine();

                    Member newMember = new Member(name, id);
                    members.Add(newMember);
                    totalMembershipFees += 10.0f; // $10 yearly membership fee[cite: 4]
                    Console.WriteLine("Member added successfully! $10 membership fee collected.");
                }
                else if (choice == 6)
                {
                    Console.Write("Enter name or ID to search: ");
                    string query = Console.ReadLine();
                    bool found = false;

                    foreach (Member m in members)
                    {
                        if (query == m.name || query == m.ID)
                        {
                            Console.WriteLine("\nMember Found:"); 
                            m.ShowMemberDetails();
                            found = true;
                            break;
                        }
                    }
                    if (!found) Console.WriteLine("Member not found.");
                }
                else if (choice == 7)
                {
                    Console.Write("Enter current name or ID of the member to update: ");
                    string query = Console.ReadLine();
                    Member targetMember = null;

                    foreach (Member m in members)
                    {
                        if (query == m.name || query == m.ID)
                        {
                            targetMember = m;
                            break;
                        }
                    }

                    if (targetMember != null)
                    {
                        Console.Write("Enter what to modify (1. Name, 2. ID, 3. Both): "); 
                        int opt = int.Parse(Console.ReadLine());
                        if (opt == 1 || opt == 3)
                        {
                            Console.Write("Enter new name: ");
                            targetMember.name = Console.ReadLine();
                        }
                        if (opt == 2 || opt == 3)
                        {
                            Console.Write("Enter new ID: ");
                            targetMember.ID = Console.ReadLine();
                        }
                        Console.WriteLine("Member information updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Member not found.");
                    }
                }
                else if (choice == 8)
                {
                    Console.Write("Enter Member ID (or enter '0' for non-member occasional buyer): ");
                    string memberIdInput = Console.ReadLine();

                    Member buyer = null;
                    if (memberIdInput != "0")
                    {
                        foreach (Member m in members)
                        {
                            if (m.ID == memberIdInput)
                            {
                                buyer = m;
                                break;
                            }
                        }
                        if (buyer == null)
                        {
                            Console.WriteLine("Member ID not found. Proceeding as non-member.");
                        }
                    }

                    Console.Write("Enter Title or ISBN of the book to purchase: ");
                    string bookQuery = Console.ReadLine();
                    Book targetBook = null;

                    foreach (Book b in inventory)
                    {
                        if (bookQuery == b.title || bookQuery == b.isbn)
                        {
                            targetBook = b;
                            break;
                        }
                    }

                    if (targetBook == null)
                    {
                        Console.WriteLine("Book not found in inventory.");
                        continue;
                    }

                    Console.Write("Enter quantity to purchase: ");
                    int quantity = int.Parse(Console.ReadLine());

                    if (targetBook.stock < quantity)
                    {
                        Console.WriteLine("Insufficient stock available!");
                        continue;
                    }

                    float finalCost = targetBook.price * quantity;

                    if (buyer != null)
                    {
                        finalCost *= 0.95f; 

                        for (int q = 0; q < quantity; q++)
                        {
                            buyer.booksbought.Add(targetBook);
                            buyer.no_books_bought++;
                            buyer.amountSpent += targetBook.price;

                          
                            if (buyer.no_books_bought % 11 == 0 && buyer.booksbought.Count >= 10)
                            {
                                float sumLast10 = 0;
                                int startIdx = buyer.booksbought.Count - 10;
                                for (int i = startIdx; i < buyer.booksbought.Count; i++)
                                {
                                    sumLast10 += buyer.booksbought[i].price;
                                }
                                float avgDiscount = sumLast10 / 10.0f;
                                finalCost = Math.Max(0, finalCost - avgDiscount);
                                buyer.amountSpent = 0.0f; 
                                Console.WriteLine($"Special 11th book discount applied: ${avgDiscount:F2} off!");
                            }
                        }
                    }

                    targetBook.stock -= quantity;
                    totalSales += finalCost;
                    Console.WriteLine($"Purchase successful! Total cost: ${finalCost:F2}");
                }
                else if (choice == 9)
                {
                    Console.WriteLine($"\n--- Bookstore Statistics ---");
                    Console.WriteLine($"Total Sales Made: ${totalSales:F2}"); 
                    Console.WriteLine($"Total Members: {members.Count}"); 
                    Console.WriteLine($"Total Membership Fees Collected: ${totalMembershipFees:F2}");
                }
                else if (choice == 10)
                {
                    Console.WriteLine("Exiting program. Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid choice! Please choose between 'a' and 'j'.");
                }

            } while (choice != 10);
        }
    }

    class Member
    {
        public string name;
        public string ID;
        public List<Book> booksbought;
        public int no_books_bought;
        public float moneyInBank;
        public float amountSpent;

        public Member()
        {
            name = "";
            ID = "0"; 
            booksbought = new List<Book>();
            no_books_bought = 0;
            moneyInBank = 0.0f;
            amountSpent = 0.0f;
        }

        public Member(string name, string ID)
        {
            this.name = name;
            this.ID = ID;
            this.booksbought = new List<Book>();
            this.no_books_bought = 0;
            this.moneyInBank = 0.0f;
            this.amountSpent = 0.0f;
        }

        public void ShowMemberDetails()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Member ID: " + ID);
            Console.WriteLine("Books Bought: " + no_books_bought);
            Console.WriteLine("Total Amount Spent: $" + amountSpent);
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
        public int yearOfPublication;

        public Book(string title, List<string> authors, int numAuthors, string publisher, string isbn, float price, int stock, int yearOfPublication)
        {
            this.title = title;
            this.authors = authors;
            this.numAuthors = numAuthors;
            this.publisher = publisher;
            this.isbn = isbn;
            this.price = price;
            this.stock = stock;
            this.yearOfPublication = yearOfPublication;
        }

        public void ShowBookDetails()
        {
            Console.WriteLine("Title: " + title);
            Console.Write("Authors: ");
            foreach (string author in authors)
            {
                Console.Write(author + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Publisher: " + publisher);
            Console.WriteLine("ISBN: " + isbn);
            Console.WriteLine("Price: $" + price);
            Console.WriteLine("Stock: " + stock);
            Console.WriteLine("Year of Publication: " + yearOfPublication);
        }
    }
}*/