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
            int age;
            Console.WriteLine("Lily's Age: ");
            age = int.Parse(Console.ReadLine());
            int price;
            Console.WriteLine("Price of Machine: ");
            price = int.Parse(Console.ReadLine());
            int unit;
            Console.WriteLine("Unit Price of toy: ");
            unit = int.Parse(Console.ReadLine());

            totalmoney(age, price, unit);


            Console.ReadKey();
        }

        static void totalmoney(int age, int price, int unit)
        {
            int money = 0;
            int count = 0;
            int gift = 10;
            for(int i=1; i<=age; i++)
            {
                if (i % 2 == 0)
                {
                    money += gift - 1;
                    gift += 10;
                }
                else
                {
                    count++;
                }
            }
            int fullmoney = (unit * count) + money;
            if (fullmoney > price)
            {
                Console.WriteLine("Yes! {0}", + fullmoney - price);
            }
            else
            {
                Console.WriteLine("No! {0}", price - fullmoney);
            }
        }

    }
}