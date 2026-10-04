using system
namespace task

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Initial Balance: ");
        double inibalance = double.Parse(Console.ReadLine());

        ATM atm = new ATM(inibalance);
        Console.WriteLine(atm.showBalance());



        Console.WriteLine("Enter Amount to deposit: ");
        double newbalance = double.Parse(Console.ReadLine());

        atm.Deposit(newbalance);
        Console.WriteLine("Current balance: " + atm.showBalance());

        Console.WriteLine("Enter amount to withdraw: ");
        double takemoney = double.Parse(Console.ReadLine());
        atm.withdraw(takemoney);
        Console.WriteLine("Current Balance: " +  atm.showBalance());

        atm.trans_his();

        Console.ReadKey();
        


    }
}

class ATM
{
    public double balance;
    List<string> history = new List<string>();

    public ATM(double balance)
    {
        this.balance = balance;
    }

    

    public void Deposit(double newbalance)
    {
        this.balance+= newbalance;
        history.Add("Deposit: " + newbalance);
    }

    public void withdraw(double takemoney)
    {
        if(takemoney > this.balance)
        {
            Console.WriteLine("You not have much money in your account to withdraw!");
        }
        else
        {
            this.balance -= takemoney;
            history.Add("Withdraw: " + takemoney);
        }
    }

    public double showBalance()
    {
        return balance;
    }

    public void trans_his()
    {
        Console.WriteLine("History: ");
        for(int i=0; i<history.Count; i++)
        {
            Console.WriteLine(history[i]);
        }
    }



}