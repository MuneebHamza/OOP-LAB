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
            /*-------------------------------input/output tasks */
            /*int number;
            string str;
            str = Console.ReadLine();
            number = int.Parse(str);
            Console.WriteLine("You have inputted: ");
            Console.WriteLine("The number is: ");
            Console.Write(number);*/

            /*float value;
            string str;
            Console.WriteLine("Enter floating point value: ");
            str = Console.ReadLine();
            value = float.Parse(str);
            Console.WriteLine("The floating value is: ");
            Console.Write(value);*/

            float length;
            string str;
            Console.WriteLine("Enter length: ");
            str = Console.ReadLine();
            length = float.Parse(str);
            float area = length * length;
            Console.WriteLine("The area is: ");
            Console.Write(area);
        }
    }
}