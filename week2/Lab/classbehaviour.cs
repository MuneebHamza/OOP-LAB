using system
namespace task

class Program { 
static void Main(string[] args)
{
    Dog mydog = new Dog();
    mydog.name = "Buddy";
    mydog.age = 3;
    mydog.bark();
    mydog.Eat("dog food");
    int humanYears = mydog.ConvertToHumanYears();
    Console.WriteLine(mydog.name + "'s age in human years: " + humanYears);

    Console.ReadKey();
}
}
public class Dog
{
    public string name;
    public int age;

    public void bark()
    {
        Console.WriteLine(name + "is barking");
    }

    public void Eat(string food)
    {
        Console.WriteLine(name + "is eating" + food);
    }

    public int ConvertToHumanYears()
    {
        return age * 7;
    }

}