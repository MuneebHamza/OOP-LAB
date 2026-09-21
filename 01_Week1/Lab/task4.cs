using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Week1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*--------------------------if/else task---------*/
            float marks;
            string input;
            Console.Write("Enter the marks: ");
            input = Console.ReadLine();
            marks = float.Parse(input);
            if(marks > 50)
            {
                Console.Write("You are passed!");
            }
            else
            {
                Console.Write("You are failed!");
            }
            Console.Readkey();
        }
    }
}