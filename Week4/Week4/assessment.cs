/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class Account
    {
        public string account_title;
        public int account_no;
        public float account_balance;
        public Account(string account_title, int account_no, float account_balance)
        {
            this.account_title = account_title;
            this.account_no = account_no;
            this.account_balance = account_balance;

        }
        public void display_account_detail()
        {
            Console.WriteLine($"account title is:{account_title},account no is:{account_no},account balance is:{account_balance}");
        }
        public void account_balance_update(float balance)
        {
            account_balance += balance;
        }
    }
    public class customer
    {
        public string name;
        public string phone_no;
        static List<Account> accounts;
        public customer(string name, string phone_no)
        {
            this.name = name;
            this.phone_no = phone_no;
            accounts = new List<Account>();
        }
        public void displaycustomer()
        {
            Console.WriteLine($"name is:{name},phone_no{phone_no}");
        }
        public void add_account(Account account)
        {
            accounts.Add(account);
        }

    }
    public class program
    {
        static void Main(string[] args)
        {
            customer c1 = new customer("taha", "0302xxxxxx");
            Account a1 = new Account("taha account", 101, 303f);
            c1.add_account(a1);
            //display before update balance
            c1.displaycustomer();
            a1.display_account_detail();
            //display after balance update
            a1.account_balance_update(200f);
            c1.displaycustomer();
            a1.display_account_detail();

        }

    }

}*/