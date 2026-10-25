/*using System;
using System.Collections.Generic;
using System.Text;

namespace Week4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Chapters = new List<string>()
            {"OOP", "DATABASE", "DLD"};
            Book b1 = new Book("C#" , "Jane" , 316 , Chapters ,0, 500, true);
            Console.WriteLine("Available: " + b1.isBookAvailable());
            Console.WriteLine("Chapters: " + b1.getChapter(2));
            Console.WriteLine("BookMark: " + b1.getBookMark());
        }
    }

    class Book
    {
        public string title;
        public string author;
        public int pages;
        public List<string> chapters;
        public int bookMark;
        public int price;
        public bool is_available;

        public Book(string title, string author, int pages, List<string> chapters, int bookMark, int price, bool is_available)
        {
            this.title = title;
            this.author = author;
            this.pages = pages;
            this.chapters = chapters ?? new List<string>();
            this.bookMark = 0;
            this.price = price;
            this.is_available = is_available;
        }

        public bool isBookAvailable()
        {
            return is_available;
        }

        public string getChapter(int chapterNumber)
        {
            return chapters[chapterNumber];
        }

        public int getBookMark()
        {
            return bookMark;
        }
    }
}*/
