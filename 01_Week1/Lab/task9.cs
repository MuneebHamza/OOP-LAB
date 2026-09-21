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
            /* =============================================== File Handling ==================================*/
            /*string path = "E:\\Semester2\\Week1\\Lab\\textfile.txt";
            if(File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while((record=file.ReadLine())!= null)
                {
                    Console.WriteLine(record);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }*/

            string path = "E:\\Semester2\\Week1\\Lab\\textfile.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine("Hello World!");
            file.Flush();
            file.Close();

            Console.ReadKey();
        }

    }
}

