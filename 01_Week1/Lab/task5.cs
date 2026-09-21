namespace Week1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*=============================loops=====================================---------*/
            /*--==================---------------for loop ------=================--------*/

            /*for(int i=0; i<5; i++)
            {
             Console.WriteLine("Welcome Jack!");
            }*/


            /*-===================-------------------While loop---================--------*/

            /*int sum = 0;
            int num;
            string input;
            Console.Write("Enter a number: ");
            input = Console.ReadLine();
            num = int.Parse(input);
            while (num != -1)
            {
                sum += num;
                Console.Write("Enter a number: ");
                input = Console.ReadLine();
                num = int.Parse(input);
            }

            Console.Write("Total sum is: " + sum);*/

            /*===============================do while loop ==================================*/

             int num;
            string input;
            int sum = 0;
            do
            {
                Console.Write("Enter a number: ");
                input = Console.ReadLine();
                num = int.Parse(input);
                sum += num;
            }

            while (num != -1);
            sum += 1;
            Console.WriteLine("Your total sum is {0}", sum);
            Console.Readkey();

        }
    }
}