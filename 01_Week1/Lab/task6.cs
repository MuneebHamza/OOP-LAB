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
            /*============================= Arrays =====================================---------*/
            int[] number = new int[3];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter three numbers {0}: ", i);
                number[i] = int.Parse(Console.ReadLine());
            }

            int largest = -1;
            for(int i=0; i<3; i++)
            {
                if (number[i] > largest)
                {
                    largest = number[i];
                }

            }
            Console.WriteLine("Largest is: {0}",largest);
            Console.Readkey();

        }
    }
}