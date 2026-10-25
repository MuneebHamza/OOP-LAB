/*using System;
using System.Collections.Generic;
using System.Text;

namespace Week4
{
    class Program
    {
        static void Main(string[] args)
        {
            const int CAPACITY = 100;
            Book[] books = new Book[CAPACITY];
            int bookCount = 0;
            int choice;

            do
            {
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. Search for a Book by Title");
                Console.WriteLine("3. Search for a Book by ISBN");
                Console.WriteLine("4. Update Number of Copies in Stock");
                Console.WriteLine("5. Display All Books");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice (1-6): ");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Write("Enter Book Title: ");
                    string title = Console.ReadLine();

                    List<string> authList = new List<string>();

                    Console.Write("Enter number of authors (up to 4): ");
                    string[] auth = new string[4];
                    for (int i = 0; i < 4; i++)
                    {
                        Console.Write($"Enter author {i + 1}: ");
                        authList.Add(Console.ReadLine());
                    }

                    Console.Write("Enter Publisher: ");
                    string pub = Console.ReadLine();

                    Console.Write("Enter ISBN: ");
                    string isbn = Console.ReadLine();

                    Console.Write("Enter Price: ");
                    double price = double.Parse(Console.ReadLine());

                    Console.Write("Enter Number of Copies in Stock: ");
                    int stock = int.Parse(Console.ReadLine());

                    books[bookCount] = new Book(title, authList, 4, pub, isbn, price, stock);
                    bookCount++;
                    Console.WriteLine("Book added successfully!");
                }
                else if (choice == 2)
                {
                    Console.Write("Enter title to search: ");
                    string searchTitle = Console.ReadLine();
                    for (int i = 0; i < bookCount; i++)
                    {
                        bool search = books[i].IsTitleSame(searchTitle);
                        if (search)
                        {
                            Console.WriteLine("Book Found:");
                            books[i].ShowBookDetails();
                        }
                        else
                        {
                            Console.WriteLine($"No book found with the title {searchTitle} .");
                        }
                    }
                }
                else if (choice == 3)
                {
                    Console.Write("Enter ISBN to search: ");
                    string searchIsbn = Console.ReadLine();


                    for (int i = 0; i < bookCount; i++)
                    {
                        bool found = books[i].IsIsbnSame(searchIsbn);
                        if (found)
                        {
                            Console.WriteLine("\nBook Found:");
                            books[i].ShowBookDetails();
                        }
                        else
                        {
                            Console.WriteLine($"No book found with the ISBN {searchIsbn}.");
                        }
                    }
                }

                else if (choice == 4)
                {
                    Console.Write("Enter ISBN of the book to update stock: ");
                    string searchIsbn = Console.ReadLine();
                    for (int i = 0; i < bookCount; i++)
                    {
                        bool found = books[i].IsIsbnSame(searchIsbn);
                        if (found)
                        {
                            Console.WriteLine($"Current stock is {books[i].stock}.");
                            Console.Write("Enter amount to add (positive): ");
                            int change = int.Parse(Console.ReadLine());

                            books[i].UpdateStock(change);
                            Console.WriteLine($"Stock updated successfully! New stock: {books[i].stock}");
                        }
                        else
                        {
                            Console.WriteLine($"Book with ISBN {searchIsbn} not found.");
                        }
                    }
                }
                else if (choice == 5)
                {

                    for (int i = 0; i < bookCount; i++)
                    {
                        books[i].ShowBookDetails();
                    }
                }

                else if (choice == 6)
                {
                    Console.WriteLine("Exiting program. Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid choice! Please choose between 1 and 6.");
                }


            } while (choice != 6);

        }

        class Book
        {
            public string title;
            public List<string> authors;
            public int numAuthors;
            public string publisher;
            public string isbn;
            public double price;
            public int stock;


            public Book()
            {
                title = "";
                authors = new List<string>();
                numAuthors = 0;
                publisher = "";
                isbn = "";
                price = 0.0;
                stock = 0;
            }


            public Book(string title,List<string> authors, int numAuthors, string publisher, string isbn, double price, int stock)
            {
                this.title = title;
                this.numAuthors = numAuthors;
                this.authors = authors;
                this.publisher = publisher;
                this.isbn = isbn;
                this.price = price;
                this.stock = stock;
            }

            public void ShowAuthors()
            {
                for (int i = 0; i < authors.Count; i++)
                {
                    Console.Write(authors[i]);
                }
                Console.WriteLine();
            }

            public void ShowBookDetails()
            {
                Console.WriteLine("Title: " + title);
                Console.Write("Authors: ");
                ShowAuthors();
                Console.WriteLine("Publisher: " + publisher);
                Console.WriteLine("ISBN: " + isbn);
                Console.WriteLine("Price: $" + price);
                Console.WriteLine("Copies in Stock: " + stock);
            }

            public void UpdateStock(int quantityChange)
            {
                stock += quantityChange;
            }

            public bool IsTitleSame(string t)
            {
                if (t == title)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool IsIsbnSame(string bookIsbn)
            {
                if (bookIsbn == isbn)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}*/

