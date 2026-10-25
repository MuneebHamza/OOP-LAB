using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.UI
{
    class inputhelper
    {
        public static int ReadInt(string prompt)
        {
            int value;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out value))
                Console.Write("Invalid input. Enter a valid number: ");
            return value;
        }

        public static float ReadFloat(string prompt)
        {
            float value;
            Console.Write(prompt);
            while (!float.TryParse(Console.ReadLine(), out value))
                Console.Write("Invalid input. Enter a valid number: ");
            return value;
        }
    }
}
