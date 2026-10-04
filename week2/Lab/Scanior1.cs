using system

namespace task

class Program
{
        static void Main(string[] args)
    {
        student s1 = new student();
        s1.name = "Ali";
        s1.ecatMarks = 300;
        s1.matricMarks = 800;
        s1.FscMarks = 980;

        student s2 =  s1;
        s2.name = "Sarmad";

        Console.WriteLine(s2.name);
        Console.WriteLine(s1.name);

        Console.ReadKey();
    }
}

public class student
{
    public string name;
    public float ecatMarks;
    public float FscMarks;
    public float matricMarks;
    public float Aggrigate;

}